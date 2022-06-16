using System.Text.Json.Serialization;

namespace SpotifyApi.NetCore.Models
{
    public partial class PlaylistRemoveItemsPayloadDataUriItems
    {

        public PlaylistRemoveItemsPayloadDataUriItems(string[] uris, string snapshotId = null)
        {
            Uris = new PlaylistRemoveItemsPayloadDataUriItem[uris.Length];
            for (int i = 0; i < Uris.Length; i++)
            {
                Uris[i] = new PlaylistRemoveItemsPayloadDataUriItem(uris[i]);
            }
            SnapshotId = snapshotId;
        }

        public PlaylistRemoveItemsPayloadDataUriItems((string uri, int[] positions)[] uriPositions, string snapshotId = null)
        {
            Uris = new PlaylistRemoveItemsPayloadDataUriItem[uriPositions.Length];
            for (int i = 0; i < Uris.Length; i++)
            {
                Uris[i] = new PlaylistRemoveItemsPayloadDataUriItem(uriPositions[i]);
            }
            SnapshotId = snapshotId;
        }

        [JsonPropertyName("tracks")]
        public PlaylistRemoveItemsPayloadDataUriItem[] Uris { get; set; }

        [JsonPropertyName("snapshot_id")]
        public string SnapshotId { get; set; }

    }

    public partial class PlaylistRemoveItemsPayloadDataUriItem
    {

        public PlaylistRemoveItemsPayloadDataUriItem(string uri) => this.Uri = uri;

        public PlaylistRemoveItemsPayloadDataUriItem((string uri, int[] positions) uriPositions)
        {
            Uri = uriPositions.uri;
            Positions = uriPositions.positions;
        }

        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        [JsonPropertyName("positions")]
        public int[] Positions { get; set; }

    }

}
