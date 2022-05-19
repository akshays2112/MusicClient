using WebApis.Net6.Spotify.Models;
using System.Text.Json;
using System.Net.Http.Headers;

namespace WebApis.Net6;

public static class Globals
{
    public enum ConstraintComparison { Equal, LessThanOrEqual, GreaterThanOrEqual }

    public static HttpClient? HttpClient { get; set; }

    public static async Task<T?> CallWebApiEndpoint<T>(WebApiEndpoint<T> webApiEndPoint, string? accessToken = null)
    {
        HttpClient ??= new();
        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        StringContent? content = null;
        if (webApiEndPoint.BodyObject is not null)
        {
            content = new StringContent(webApiEndPoint.GetBodyJsonString() ?? string.Empty);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
        HttpRequestMessage request = new(webApiEndPoint.HttpMethod ?? HttpMethod.Get,
            webApiEndPoint.GetQueryString())
        {
            Content = content
        };
        HttpResponseMessage httpResponseMessage = await HttpClient.SendAsync(request);
        if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
        {
            if (typeof(T) == typeof(EmptyResponse)) return default;
            string response = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(response);
        }
        return default;
    }
}
