using System.Net;
using WApiGlobals = WebApis.Net6.Globals;
using WApiSpotifyGlobals = WebApis.Net6.Spotify.Globals;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace WebApis.Net6.Spotify;

public static class Authentication
{
    public static void GetASPNetCoreSpotifyCode(NavigationManager navigationManager)
    {
        if (string.IsNullOrWhiteSpace(WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken))
        {

            string scopes = WebUtility.UrlEncode($"{WApiSpotifyGlobals.Scopes.user_read_playback_position.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_read_email.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_library_read.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_top_read.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.playlist_modify_public.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_follow_read.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_read_playback_state.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_modify_playback_state.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_read_private.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.playlist_read_private.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_library_modify.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.playlist_read_collaborative.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.playlist_modify_private.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_follow_modify.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_read_currently_playing.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_read_recently_played.ToString().Replace('_', '-')}");
            string redirectUri = WebUtility.UrlEncode(WApiGlobals.HttpClient?.BaseAddress?.ToString() ?? "");
            navigationManager.NavigateTo($"https://accounts.spotify.com/authorize?response_type=code&client_id={WApiSpotifyGlobals.SpotifyClientId}&scope={scopes}&redirect_uri={redirectUri}", true);
        }
    }

    public static async Task GetSpotifyAccessToken(NavigationManager navigationManager)
    {
        string queryString = navigationManager.ToAbsoluteUri(navigationManager.Uri).Query;
        if (!string.IsNullOrWhiteSpace(queryString) && queryString.StartsWith("?code=") && queryString.Length > 6 &&
            string.IsNullOrWhiteSpace(WApiSpotifyGlobals.SpotifyAccessToken?.AccessToken) && 
            WApiGlobals.HttpClient is not null)
        {
            string credentials = String.Format("{0}:{1}", WApiSpotifyGlobals.SpotifyClientId, 
                WApiSpotifyGlobals.SpotifyClientSecret);
            WApiGlobals.HttpClient.DefaultRequestHeaders.Accept.Clear();
            WApiGlobals.HttpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));
            WApiGlobals.HttpClient.DefaultRequestHeaders.Authorization = new("Basic", 
                Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));
            //Prepare Request Body
            List<KeyValuePair<string, string>> requestData = new()
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", queryString.Substring(6)),
                new KeyValuePair<string, string>("redirect_uri", WApiGlobals.HttpClient.BaseAddress?.ToString() ?? string.Empty)
            };

            FormUrlEncodedContent requestBody = new(requestData);

            //Request Token
            var request = await WApiGlobals.HttpClient.PostAsync("https://accounts.spotify.com/api/token", requestBody);
            if (request.StatusCode == HttpStatusCode.OK)
            {
                string response = await request.Content.ReadAsStringAsync();
                WApiSpotifyGlobals.SpotifyAccessToken = JsonSerializer.Deserialize<SpotifyAccessToken>(response);
            }
        }
    }
}
