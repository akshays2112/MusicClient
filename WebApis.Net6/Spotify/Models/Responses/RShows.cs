using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models.Responses;

public class RShows
{
    [JsonPropertyName("shows")]
    public Show[]? Shows { get; set; }
}
