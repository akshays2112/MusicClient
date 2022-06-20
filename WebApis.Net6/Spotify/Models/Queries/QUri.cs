using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models.Queries;

public class QUri
{
    [JsonPropertyName("uri")]
    public string? Uri { get; set; }
}
