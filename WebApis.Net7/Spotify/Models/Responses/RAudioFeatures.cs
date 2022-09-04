using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models.Responses;

public class RAudioFeatures
{
    [JsonPropertyName("audio_features")]
    public AudioFeature[]? AudioFeatures { get; set; }
}
