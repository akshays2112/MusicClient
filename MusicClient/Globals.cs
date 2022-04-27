using System.Text.Json.Serialization;
using MusicClient.Data.SQLServer.Models.Spotify;
using MusicClient.Data.SQLServer.MusicClientDbOperations.Spotify;

namespace MusicClient
{
    public static class Globals
    {
        public static string RedirectUri = string.Empty;
        public static SpotifyAccessToken? SpotifyAccessToken { get; set; }
        public static string? SpotifyClientId { get; set; }
        public static string? SpotifyClientSecret { get; set; }
    }

    public class SpotifyAccessToken
    {
        [JsonPropertyName("access_token")]
        public string? AccessToken { get; set; }
        [JsonPropertyName("token_type")]
        public string? TokenType { get; set; }
        [JsonPropertyName("scope")]
        public string? Scope { get; set; }
        [JsonPropertyName("expires_in")]
        public long ExpiresIn { get; set; }
        [JsonPropertyName("refresh_token")]
        public string? RefreshToken { get; set; }
    }
}
