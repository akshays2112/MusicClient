using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models.Responses;

public class RArtists
{
    [JsonPropertyName("artists")]
    public Artist[]? Artists { get; set; }
}
