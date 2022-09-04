using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models.Responses;

public class RPagedPlaylists
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("playlists")]
    public Paged<Playlist>? Playlists { get; set; }
}
