using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models;

public class AnalysisTrack
{
    [JsonPropertyName("num_samples")]
    public int? NumSamples { get; set; }

    [JsonPropertyName("duration")]
    public float? Duration { get; set; }

    [JsonPropertyName("sample_md5")]
    public string? SampleMd5 { get; set; } = string.Empty;

    [JsonPropertyName("offset_seconds")]
    public int? OffsetSeconds { get; set; }

    [JsonPropertyName("window_seconds")]
    public int? WindowSeconds { get; set; }

    [JsonPropertyName("analysis_sample_rate")]
    public int? AnalysisSampleRate { get; set; }

    [JsonPropertyName("analysis_channels")]
    public int? AnalysisChannels { get; set; }

    [JsonPropertyName("end_of_fade_in")]
    public float? EndOfFadeIn { get; set; }

    [JsonPropertyName("loudness")]
    public float? Loudness { get; set; }

    [JsonPropertyName("tempo")]
    public float? Tempo { get; set; }

    [JsonPropertyName("tempo_confidence")]
    public float? TempoConfidence { get; set; }

    [JsonPropertyName("time_signature")]
    public int? TimeSignature { get; set; }

    [JsonPropertyName("time_signature_confidence")]
    public float? TimeSignatureConfidence { get; set; }

    [JsonPropertyName("key")]
    public int? Key { get; set; }

    [JsonPropertyName("key_confidence")]
    public float? KeyConfidence { get; set; }

    [JsonPropertyName("mode")]
    public int? Mode { get; set; }

    [JsonPropertyName("mode_confidence")]
    public float? ModeConfidence { get; set; }

    [JsonPropertyName("codestring")]
    public string? Codestring { get; set; } = string.Empty;

    [JsonPropertyName("code_version")]
    public float? CodeVersion { get; set; }

    [JsonPropertyName("echoprintstring")]
    public string? Echoprintstring { get; set; } = string.Empty;

    [JsonPropertyName("echoprint_version")]
    public float? EchoprintVersion { get; set; }

    [JsonPropertyName("synchstring")]
    public string? Synchstring { get; set; } = string.Empty;

    [JsonPropertyName("synch_version")]
    public float? SynchVersion { get; set; }

    [JsonPropertyName("rhythmstring")]
    public string? Rhythmstring { get; set; } = string.Empty;

    [JsonPropertyName("rhythm_version")]
    public float? RhythmVersion { get; set; }
}
