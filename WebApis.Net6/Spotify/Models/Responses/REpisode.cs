using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models.Responses;

public class RShow
{
    [JsonPropertyName("added_at")]
    public DateTime? AddedAt { get; set; }

    [JsonPropertyName("show")]
    public Show? Show { get; set; }
}
