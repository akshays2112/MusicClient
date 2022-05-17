using System.Text.Json.Serialization;
using static WebApis.Net6.Spotify.Globals;

namespace WebApis.Net6.Spotify.Models
{
    public class Album
    {
        [JsonPropertyName("album_type")]
        public AlbumType AlbumType { get; set; }

        [JsonPropertyName("total_tracks")]
        public int TotalTracks { get; set; }

        [JsonPropertyName("available_markets")]
        public string[] AvailableMarkets { get; set; } = Array.Empty<string>();

        [JsonPropertyName("external_urls")]
        public ExternalUrl[] ExternalUrls { get; set; } = Array.Empty<ExternalUrl>();

        [JsonPropertyName("href")]
        public string Href { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("images")]
        public Image[] Images { get; set; } = Array.Empty<Image>();

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonPropertyName("release_date_precision")]
        public ReleaseDatePrecision ReleaseDatePrecision { get; set; }

        [JsonPropertyName("restrictions")]
        public Restriction[] Restrictions { get; set; } = Array.Empty<Restriction>();

        [JsonPropertyName("type")]
        public ObjectType Type { get; set; } = ObjectType.album;

        [JsonPropertyName("uri")]
        public string Uri { get; set; } = string.Empty;

        [JsonPropertyName("artists")]
        public Artist[] Artists { get; set; } = Array.Empty<Artist>();

        [JsonPropertyName("tracks")]
        public Paged<Track>? Tracks { get; set; }
    }
}
