using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models;

public class AnalysisSection
{
    [JsonPropertyName("start")]
    public float? Start { get; set; }

    [JsonPropertyName("duration")]
    public float? Duration { get; set; }

    [JsonPropertyName("confidence")]
    public float? Confidence { get; set; }

    [JsonPropertyName("loudness")]
    public float? Loudness { get; set; }

    [JsonPropertyName("tempo")]
    public float? Tempo { get; set; }

    [JsonPropertyName("tempo_confidence")]
    public float? TempoConfidence { get; set; }

    [JsonPropertyName("key")]
    public int? Key { get; set; }

    [JsonPropertyName("key_confidence")]
    public float? KeyConfidence { get; set; }

    [JsonPropertyName("mode")]
    public float? Mode { get; set; }

    [JsonPropertyName("mode_confidence")]
    public float? ModeConfidence { get; set; }

    [JsonPropertyName("time_signature")]
    public int? TimeSignature { get; set; }

    [JsonPropertyName("time_signature_confidence")]
    public float? TimeSignatureConfidence { get; set; }
}
