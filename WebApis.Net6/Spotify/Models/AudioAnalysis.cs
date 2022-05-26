using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models;

public class AudioAnalysis
{
    [JsonPropertyName("meta")]
    public AnalysisMeta? Meta { get; set; }

    [JsonPropertyName("track")]
    public AnalysisTrack? Track { get; set; }

    [JsonPropertyName("bars")]
    public AnalysisBar[]? Bars { get; set; }

    [JsonPropertyName("beats")]
    public AnalysisBeat[]? Beats { get; set; }

    [JsonPropertyName("sections")]
    public AnalysisSection[]? Sections { get; set; }

    [JsonPropertyName("segments")]
    public AnalysisSegment[]? Segments { get; set; }

    [JsonPropertyName("tatums")]
    public AnalysisTatum[]? Tatums { get; set; }
}
