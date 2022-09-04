using System.Text.Json.Serialization;

namespace WebApis.Net7.Spotify.Models;

public class Device
{
    [JsonPropertyName("id")]
    public string? Id { get; set; } = string.Empty;

    [JsonPropertyName("is_active")]
    public bool? IsActive { get; set; }

    [JsonPropertyName("is_private_session")]
    public bool? IsPrivateSession { get; set; }

    [JsonPropertyName("is_restricted")]
    public bool? IsRestricted { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string? Type { get; set; } = string.Empty;

    [JsonPropertyName("volume_percent")]
    public int? VolumePercent { get; set; }
}
