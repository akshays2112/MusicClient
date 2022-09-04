using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models.Responses;

public class RAlbum
{
    [JsonPropertyName("added_at")]
    public DateTime AddedAt { get; set; }

    [JsonPropertyName("album")]
    public Album? Album { get; set; }
}
