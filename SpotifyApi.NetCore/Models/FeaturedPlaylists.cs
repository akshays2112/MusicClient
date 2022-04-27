using System.Text.Json.Serialization;

namespace SpotifyApi.NetCore
{
    public class FeaturedPlaylists : PagedPlaylists
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
