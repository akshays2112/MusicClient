using System.Text.Json.Serialization;

namespace SpotifyApi.NetCore
{
    public partial class CurrentTrackPlaybackContext : CurrentPlaybackContext
    {
        ///<summary>
        /// The currently playing track. Can be null.
        ///</summary>
        [JsonPropertyName("item")]
        public Track Item { get; set; }
    }
}
