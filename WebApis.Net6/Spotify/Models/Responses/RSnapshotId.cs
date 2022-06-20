using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models.Responses;

public class RSnapshotId
{
    [JsonPropertyName("snapshot_id")]
    public string? SnapshotId { get; set; }
}
