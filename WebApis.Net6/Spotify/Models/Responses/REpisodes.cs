using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models.Responses;

public class REpisodes
{
    [JsonPropertyName("episodes")]
    public Episode[]? Episodes { get; set; }
}
