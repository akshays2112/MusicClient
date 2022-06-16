using Microsoft.AspNetCore.Components;
using System.Net;
using System.Text;
using System.Text.Json;

namespace WebApis.Net6.Spotify;

public class SpotifyAuthentication : ISpotifyAuthentication
{
    private readonly IWApiGlobals _wApiGlobals;
    private readonly IWApiSpotifyGlobals _wApiSpotifyGlobals;
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;

    public SpotifyAuthentication(IWApiGlobals wApiGlobals, IWApiSpotifyGlobals wApiSpotifyGlobals, 
        HttpClient httpClient, NavigationManager navigationManager)
    {
        _wApiGlobals = wApiGlobals;
        _wApiSpotifyGlobals = wApiSpotifyGlobals;
        _httpClient = httpClient;
        _navigationManager = navigationManager;
    }

    public void GetSpotifyApiCode()
    {
        if (string.IsNullOrWhiteSpace(_wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken))
        {
            string scopes = WebUtility.UrlEncode($"{WApiSpotifyGlobals.Scopes.user_read_playback_position.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_read_email.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_library_read.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_top_read.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.playlist_modify_public.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_follow_read.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_read_playback_state.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_modify_playback_state.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_read_private.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.playlist_read_private.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_library_modify.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.playlist_read_collaborative.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.playlist_modify_private.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_follow_modify.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_read_currently_playing.ToString().Replace('_', '-')} {WApiSpotifyGlobals.Scopes.user_read_recently_played.ToString().Replace('_', '-')}");
            string redirectUri = WebUtility.UrlEncode(_httpClient?.BaseAddress?.ToString() ?? "");
            _navigationManager.NavigateTo($"https://accounts.spotify.com/authorize?response_type=code&client_id={_wApiSpotifyGlobals.SpotifyClientId}&scope={scopes}&redirect_uri={redirectUri}", true);
        }
    }

    public async Task GetSpotifyAccessToken()
    {
        string queryString = _navigationManager.ToAbsoluteUri(_navigationManager.Uri).Query;
        if (!string.IsNullOrWhiteSpace(queryString) && queryString.StartsWith("?code=") && queryString.Length > 6 &&
            string.IsNullOrWhiteSpace(_wApiSpotifyGlobals.SpotifyAccessToken?.AccessToken) &&
            _httpClient is not null)
        {
            string credentials = String.Format("{0}:{1}", _wApiSpotifyGlobals.SpotifyClientId, _wApiSpotifyGlobals.SpotifyClientSecret);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));
            //Prepare Request Body
            List<KeyValuePair<string, string>> requestData = new()
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", queryString[6..]),
                new KeyValuePair<string, string>("redirect_uri", _httpClient.BaseAddress?.ToString() ?? string.Empty)
            };

            FormUrlEncodedContent requestBody = new(requestData);

            //Request Token
            var request = await _httpClient.PostAsync("https://accounts.spotify.com/api/token", requestBody);
            if (request.StatusCode == HttpStatusCode.OK)
            {
                string response = await request.Content.ReadAsStringAsync();
                _wApiSpotifyGlobals.SpotifyAccessToken = JsonSerializer.Deserialize<SpotifyAccessToken>(response);
            }
        }
    }
}
