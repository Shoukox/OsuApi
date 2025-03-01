using OsuApi.Core.V2.GrantAccessUtility.Models;
using OsuApi.Core.V2.GrantAccessUtility.Models.HttpIO;
using System.Net.Http.Json;

namespace OsuApi.Core.V2.GrantAccessUtility
{
    public class GrantAccess
    {
        private int _clientId;
        private string _clientSecret;
        private ClientCredentialsGrantResponse? _grantAccessResponse;
        private HttpClient _httpClient;

        private int _updatedCount;
        private DateTime _nextUpdateDateTime;

        private GrantAccess(int client_id, string client_secret, HttpClient httpClient) => (_clientId, _clientSecret, _httpClient) = (client_id, client_secret, httpClient);

        public static GrantAccess Initialize(int client_id, string client_secret, HttpClient client) => new GrantAccess(client_id, client_secret, client);

        private async Task<ClientCredentialsGrantResponse?> MakeRequest()
        {
            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, ApiV2.ApiGrantAccessBaseAddress);

            var body = new ClientCredentialsGrantRequest()
            {
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                GrantType = GrantType.ClientCredentials,
                Scope = Scope.Public
            };
            httpRequest.Content = JsonContent.Create(body);

            var httpResponse = await _httpClient.SendAsync(httpRequest, CancellationToken.None);
            return await httpResponse.Content.ReadFromJsonAsync<ClientCredentialsGrantResponse>();

        }

        private void UpdateTimers()
        {
            if (_grantAccessResponse == null) throw new Exception();

            int seconds = (int)(_grantAccessResponse.ExpiresIn * 0.9); // Update after 90% of given time has passed
            _nextUpdateDateTime = DateTime.Now.AddSeconds(seconds);
        }

        public async Task<ClientCredentialsGrantResponse> GetClientCredentialGrant()
        {
            _grantAccessResponse = await MakeRequest();
            if (_grantAccessResponse == null) throw new Exception();

            UpdateTimers();

            return _grantAccessResponse;
        }

        private TimeSpan GetLeftTimeForNextUpdate() => _nextUpdateDateTime - DateTime.Now;

        public async Task StartWorker(CancellationToken token, bool firstlyWaitThenUpdate = true)
        {
            // todo
            // reimplement to the impl like in python realization
            if (firstlyWaitThenUpdate) await Task.Delay((int)GetLeftTimeForNextUpdate().TotalMilliseconds);

            while (!token.IsCancellationRequested)
            {
                await GetClientCredentialGrant();

                await Task.Delay((int)GetLeftTimeForNextUpdate().TotalMilliseconds);
                _updatedCount += 1;
            }
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
    }
}
