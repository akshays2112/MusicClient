using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models;

public class PlaybackState
{
    [JsonPropertyName("device")]
    public Device? Device { get; set; }

    [JsonPropertyName("repeat_state")]
    public string? RepeatState { get; set; } = string.Empty;

    [JsonPropertyName("shuffle_state")]
    public string? ShuffleState { get; set; } = string.Empty;

    [JsonPropertyName("context")]
    public Context? Context { get; set; }

    [JsonPropertyName("timestamp")]
    public int? Timestamp { get; set; }

    [JsonPropertyName("progress_ms")]
    public int? ProgressMs { get; set; }

    [JsonPropertyName("is_playing")]
    public bool? IsPlaying { get; set; }

    [JsonPropertyName("item")]
    public Track? Item { get; set; }

    [JsonPropertyName("currently_playing_type")]
    public string? CurrentlyPlayingType { get; set; } = string.Empty;

    [JsonPropertyName("actions")]
    public Actions? Actions { get; set; }
}
