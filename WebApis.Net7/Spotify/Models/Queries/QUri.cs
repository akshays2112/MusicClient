using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models.Queries;

public class QUri
{
    [JsonPropertyName("uri")]
    public string? Uri { get; set; }
}
