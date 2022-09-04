using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models;

public class OwnerAllOf
{
    public UserProfile? Profile { get; set; }

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }
}
