using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models.Responses;

public class REpisode
{
    [JsonPropertyName("added_at")]
    public DateTime? AddedAt { get; set; }

    [JsonPropertyName("episode")]
    public Episode? Episode { get; set; }
}
