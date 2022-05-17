using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models
{
    public class ExplicitContent
    {
        [JsonPropertyName("filter_enabled")]
        public bool? FilterEnabled { get; set; }

        [JsonPropertyName("filter_locked")]
        public bool? FilterLocked { get; set; }
    }
}
