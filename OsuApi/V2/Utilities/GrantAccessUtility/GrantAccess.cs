﻿using System.Net.Http.Json;
using OsuApi.V2.Utilities.GrantAccessUtility.HttpIO;

namespace OsuApi.V2.Utilities.GrantAccessUtility
{
    public class GrantAccess : IDisposable
    {
        public const string ApiGrantAccessBaseAddress = "https://osu.ppy.sh/oauth/token";

        private Api _api;
        private ApiConfiguration _apiConfiguration;
        private ClientCredentialsGrantResponse? _grantAccessResponse;
        private DateTime? _nextUpdateDateTime;
        private SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public GrantAccess(ApiConfiguration apiConfiguration, Api api) => (_apiConfiguration, _api) = (apiConfiguration, api);

        public async Task ClientCredentialGrant()
        {
            var body = new ClientCredentialsGrantRequest()
            {
                ClientId = _apiConfiguration.ClientId,
                ClientSecret = _apiConfiguration.ClientSecret,
                GrantType = GrantType.ClientCredentials,
                Scope = Scope.Public
            };

            _grantAccessResponse = await _api.MakeRequestAsync<ClientCredentialsGrantResponse>(ApiGrantAccessBaseAddress, HttpMethod.Post, null, JsonContent.Create(body), false, false);
            if (_grantAccessResponse == null) throw new Exception();

            UpdateTimers();
#if DEBUG
            Console.WriteLine("gotToken {0}", DateTime.Now.ToString("g"));
#endif
        }

        private TimeSpan GetLeftTimeForNextUpdate()
        {
            if (_nextUpdateDateTime == null) throw new Exception();
            return _nextUpdateDateTime.Value - DateTime.Now;
        }

        private bool ShouldUpdateToken() => GetLeftTimeForNextUpdate() < TimeSpan.Zero;

        private void UpdateTimers()
        {
            if (_grantAccessResponse == null) throw new Exception();

            int seconds = (int)(_grantAccessResponse.ExpiresIn * 0.9); // Update after 90% of given time has passed
            _nextUpdateDateTime = DateTime.Now.AddSeconds(seconds);
        }

        public async Task UpdateTokenIfNeeded()
        {
            if (!ShouldUpdateToken()) return;
            if (!await _semaphore.WaitAsync(0)) return;

            await ClientCredentialGrant();
            _semaphore.Release();
        }

        public string GetTokenType()
        {
            if (_grantAccessResponse == null || _grantAccessResponse.TokenType == null) throw new Exception();

            return _grantAccessResponse.TokenType;
        }

        public string GetAccessToken()
        {
            if (_grantAccessResponse == null || _grantAccessResponse.AccessToken == null) throw new Exception();

            return _grantAccessResponse.AccessToken;
        }

        #region Dispose
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_semaphore != null) _semaphore.Dispose();
                }

                _grantAccessResponse = null;
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
