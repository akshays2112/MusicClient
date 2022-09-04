using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models.Queries;

public class QTracks
{
    [JsonPropertyName("tracks")]
    public QUri[]? Tracks { get; set; }
}
