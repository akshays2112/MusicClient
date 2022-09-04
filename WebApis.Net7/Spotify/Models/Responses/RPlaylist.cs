using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models.Responses;

public class RPlaylist
{
    [JsonPropertyName("added_at")]
    public DateTime? AddedAt { get; set; }

    [JsonPropertyName("playlist")]
    public Playlist? Playlist { get; set; }
}
