using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models
{
    public class AlbumGroupArtists
    {
        [JsonPropertyName("album_group")]
        public string AlbumGroup { get; set; } = string.Empty;

        [JsonPropertyName("artists")]
        public Artist[] Artists { get; set; } = Array.Empty<Artist>();
    }
}
