using WebApis.Net6.Spotify.Models;
using System.Text.Json;
using System.Net.Http.Headers;

namespace WebApis.Net6.Spotify
{
    public static class Globals
    {
        public const string ApiUrl = "https://api.spotify.com/v1";

        public static SpotifyAccessToken? SpotifyAccessToken { get; set; }

        #region UserProfile

        ///<summary>
        ///Get Current User's Profile
        ///Get detailed profile information about the current user (including the current user's username).
        /// </summary>
        public static WebApiEndpoint<UserProfile> GetCurrentUsersProfile()
            => new() { HttpMethod = HttpMethod.Get, EndPointUrl = "/me" };

        ///<summary>
        ///Follow Artists or Users
        ///Add the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        public static WebApiEndpoint<EmptyResponse> PutFollowArtistsOrUsers()
            => new() { HttpMethod = HttpMethod.Put, EndPointUrl = "/me/following" };

        #endregion

        public static async Task<T?> CallWebApiEndpoint<T>(WebApiEndpoint<T> webApiEndPoint)
        {
            HttpClient httpClient = new();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SpotifyAccessToken?.AccessToken);
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
            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(request);
            if(httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (typeof(T) == typeof(EmptyResponse)) return default; 
                string response = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(response);
            }
            return default;
        }
    }
}
