using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models.Responses;

public class RPagedArtists
{
    [JsonPropertyName("artists")]
    public Paged<Artist>? Artists { get; set; }
}
