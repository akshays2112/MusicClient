using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models.Responses;

public class RPagedAlbums
{
    [JsonPropertyName("albums")]
    public Paged<Album>? Albums { get; set; }
}
