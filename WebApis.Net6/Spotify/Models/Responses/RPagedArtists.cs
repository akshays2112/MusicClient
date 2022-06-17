using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models.Responses;

public class RPagedArtists
{
    [JsonPropertyName("artists")]
    public Paged<Artist>? Artists { get; set; }
}
