﻿using WebApis.Net6.Spotify.Models;
using System.Text.Json;
using System.Net.Http.Headers;

namespace WebApis.Net6;

public static class WApiGlobals
{
    public enum ConstraintComparison
    {
        Equal = 0b1000_0000, LessThanOrEqual = 0b0100_0000,
        GreaterThanOrEqual = 0b0010_0000, Length = 0b0001_0000, Count = 0b0000_1000
    }

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