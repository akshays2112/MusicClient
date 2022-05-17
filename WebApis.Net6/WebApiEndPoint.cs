using System.Net;
using System.Text;
using System.Text.Json;
using SpotifyGlobals = WebApis.Net6.Spotify.Globals;

namespace WebApis.Net6
{
    public class WebApiEndpoint<T>
    {
        public HttpMethod? HttpMethod { get; set; }

        public string? EndPointUrl { get; set; } = string.Empty;

        public EndPointUrlPlaceholder[]? EndPointUrlPlaceholders { get; set; } = Array.Empty<EndPointUrlPlaceholder>();

        public QueryParameter[]? QueryParameters { get; set; } = Array.Empty<QueryParameter>();

        public string? GetQueryString()
        {
            StringBuilder queryString = new($"{SpotifyGlobals.ApiUrl}{EndPointUrl}");
            if (QueryParameters is null || QueryParameters?.Length == 0) return queryString.ToString();
            queryString.Append('?');
            for (int i = 0; i < QueryParameters?.Length; i++)
            {
                queryString.Append($"{QueryParameters[i].Name}={WebUtility.UrlEncode(QueryParameters[i].SimpleValue)}&");
            }
            string retStr = queryString.ToString();
            return (retStr[^1] == '&' ? retStr[..^1] : retStr);
        }

        public object? BodyObject { get; set; }

        public string? GetBodyJsonString()
        { 
            if (BodyObject is null) return null;
            return JsonSerializer.Serialize(BodyObject);
        }

        public T? Response { get; set; }
    }
}
