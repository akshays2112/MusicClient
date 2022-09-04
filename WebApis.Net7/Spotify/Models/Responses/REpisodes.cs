using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models.Responses;

public class REpisodes
{
    [JsonPropertyName("episodes")]
    public Episode[]? Episodes { get; set; }
}
