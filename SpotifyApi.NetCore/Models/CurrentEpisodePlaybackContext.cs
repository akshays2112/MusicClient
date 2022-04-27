using System.Text.Json.Serialization;

namespace SpotifyApi.NetCore
{
    public partial class CurrentEpisodePlaybackContext : CurrentPlaybackContext
    {
        /// <summary>
        /// The currently playing Episode. Can be null.
        /// </summary>
        [JsonPropertyName("item")]
        public Episode Item { get; set; }
    }
}
