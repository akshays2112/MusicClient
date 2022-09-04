using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models;

public class Search
{
    [JsonPropertyName("tracks")]
    public Paged<Track>? Tracks { get; set; }

    [JsonPropertyName("artists")]
    public Paged<Artist>? Artists { get; set; }

    [JsonPropertyName("albums")]
    public Paged<Album>? Albums { get; set; }

    [JsonPropertyName("playlists")]
    public Paged<Playlist>? Playlists { get; set; }

    [JsonPropertyName("shows")]
    public Paged<Show>? Shows { get; set; }

    [JsonPropertyName("episodes")]
    public Paged<Episode>? Episodes { get; set; }
}
