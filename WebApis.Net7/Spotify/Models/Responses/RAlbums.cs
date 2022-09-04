using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models.Responses;

public class RAlbums
{
    [JsonPropertyName("albums")]
    public Album[]? Albums { get; set; }
}
