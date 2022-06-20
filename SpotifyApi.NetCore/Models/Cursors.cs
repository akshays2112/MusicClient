using System.Text.Json.Serialization;

namespace SpotifyApi.NetCore
{
    public class Cursors
    {
        ///<summary>
        /// The cursor to use as key to find the next page of items.
        ///</summary>
        [JsonPropertyName("after")]
        public string After { get; set; }

        ///<summary>
        /// The cursor to use as key to find the previous page of items.
        ///</summary>
        [JsonPropertyName("before")]
        public string Before { get; set; }
    }
}
