using System.Net.Http.Headers;
using System.Reflection;
using OsuApi.V2.Extensions.Attributes;

namespace OsuApi.V2.Extensions;

public static class HttpRequestMessageExtensions
{
    public static void SetQueryParameters(this HttpRequestMessage hrm, PropertyInfo[] jsonProperties,
        object parametersClassInstance)
    {
        var uriBuilder = new UriBuilder(hrm.RequestUri!);
        var shouldBeQuestionMark = !uriBuilder.Query.Contains('?');
        var query = uriBuilder.Query;
        foreach (var field in jsonProperties)
        {
            var queryParameterName = field.GetCustomAttribute<QueryParameterAttribute>()?.Name;
            if (queryParameterName == null) throw new Exception();

            var value = field.GetValue(parametersClassInstance);
            if (value == null) continue;

            char getSeparator()
            {
                return shouldBeQuestionMark ? '?' : '&';
            }

            string getQueryParameter(string name, string value)
            {
                return $"{getSeparator()}{name}={value}";
            }

            var stringValue = "";
            if (value.GetType().IsArray)
            {
                var array = (Array)value;
                foreach (var item in array)
                {
                    stringValue = item.ToString();
                    if (stringValue == null) continue;

                    query += getQueryParameter(queryParameterName, stringValue);
                    shouldBeQuestionMark = false;
                }

                continue;
            }

            stringValue = value.ToString();

            if (!string.IsNullOrEmpty(stringValue)) query += getQueryParameter(queryParameterName, stringValue);

            shouldBeQuestionMark = false;
        }

        uriBuilder.Query = query;
        hrm.RequestUri = uriBuilder.Uri;
    }

    public static void SetAcceptHeader(this HttpRequestMessage hrm, string header)
    {
        hrm.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(header));
    }

    public static void SetAuthorizationHeader(this HttpRequestMessage hrm, string header)
    {
        hrm.Headers.Authorization = AuthenticationHeaderValue.Parse(header);
    }
}