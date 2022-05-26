using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models;

public class AnalysisMeta
{
    [JsonPropertyName("analyzer_version")]
    public string? AnalyzerVersion { get; set; } = string.Empty;

    [JsonPropertyName("platform")]
    public string? Platform { get; set; } = string.Empty;

    [JsonPropertyName("detailed_status")]
    public string? DetailedStatus { get; set; } = string.Empty;

    [JsonPropertyName("status_code")]
    public int? StatusCode { get; set; }

    [JsonPropertyName("timestamp")]
    public int? Timestamp { get; set; }

    [JsonPropertyName("analysis_time")]
    public float? AnalysisTime { get; set; }

    [JsonPropertyName("input_process")]
    public string? InputProcess { get; set; } = string.Empty;
}
