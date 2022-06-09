using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models.Responses;

public class RAlbums
{
    [JsonPropertyName("albums")]
    public Album[]? Albums { get; set; }
}
