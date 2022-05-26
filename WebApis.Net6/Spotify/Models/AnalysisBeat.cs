using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models;

public class AnalysisBeat
{
    [JsonPropertyName("start")]
    public float? Start { get; set; }

    [JsonPropertyName("duration")]
    public float? Duration { get; set; }

    [JsonPropertyName("confidence")]
    public float? Confidence { get; set; }
}
