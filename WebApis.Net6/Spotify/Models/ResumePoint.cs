using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models
{
    public class ResumePoint
    {
        [JsonPropertyName("fully_played")]
        public bool? FullyPlayed { get; set; }

        [JsonPropertyName("resume_position_ms")]
        public int? ResumePositionMs { get; set; }
    }
}
