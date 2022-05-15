using System.Text.Json.Serialization;

namespace SpotifyApi.NetCore
{
    public class PlaylistDetails
    {
        /// <summary>
        /// The name for the new playlist, for example "Your Coolest Playlist". This name does not 
        /// need to be unique; a user may have several playlists with the same name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Defaults to true. If true the playlist will be public, if false it will be private. To 
        /// be able to create private playlists, the user must have granted the playlist-modify-private scope .
        /// </summary>
        [JsonPropertyName("public")]
        public bool? Public { get; set; } = true;

        /// <summary>
        /// Defaults to false. If true the playlist will be collaborative. Note that to create a collaborative 
        /// playlist you must also set public to false . To create collaborative playlists you must have 
        /// granted playlist-modify-private and playlist-modify-public scopes.
        /// </summary>
        [JsonPropertyName("collaborative")]
        public bool? Collaborative { get; set; } = false;

        /// <summary>
        /// Value for playlist description as displayed in Spotify Clients and in the Web API.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}