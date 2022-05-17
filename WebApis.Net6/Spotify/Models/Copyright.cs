using System.Text.Json.Serialization;
using static WebApis.Net6.Spotify.Globals;

namespace WebApis.Net6.Spotify.Models
{
    public class Copyright
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public CopyrightType CopyrightType { get; set; }
    }
}
