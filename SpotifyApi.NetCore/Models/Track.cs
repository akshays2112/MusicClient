// Generated by https://quicktype.io
using System.Text.Json.Serialization;

namespace SpotifyApi.NetCore
{
    ///<summary>
    /// track object (full)
    ///</summary>
    public partial class Track
    {
        ///<summary>
        /// The album on which the track appears.
        ///</summary>
        [JsonPropertyName("album")]
        public Album Album { get; set; }

        ///<summary>
        /// The artists who performed the track. 
        ///</summary>
        [JsonPropertyName("artists")]
        public Artist[] Artists { get; set; }

        ///<summary>
        /// A list of the countries in which the track can be played, identified by their ISO 3166-1 alpha-2 code.
        ///</summary>
        [JsonPropertyName("available_markets")]
        public string[] AvailableMarkets { get; set; }

        ///<summary>
        /// The disc number (usually 1 unless the album consists of more than one disc).
        ///</summary>
        [JsonPropertyName("disc_number")]
        public int DiscNumber { get; set; }

        ///<summary>
        /// The track length in milliseconds.
        ///</summary>
        [JsonPropertyName("duration_ms")]
        public int DurationMs { get; set; }

        ///<summary>
        /// Whether or not the track has explicit lyrics ( true = yes it does; false = no it does not OR unknown).
        ///</summary>
        [JsonPropertyName("explicit")]
        public bool Explicit { get; set; }

        ///<summary>
        /// Known external IDs for the track.
        ///</summary>
        [JsonPropertyName("external_ids")]
        public ExternalIds ExternalIds { get; set; }

        ///<summary>
        /// Known external URLs for this track.
        ///</summary>
        [JsonPropertyName("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }

        ///<summary>
        /// A link to the Web API endpoint providing full details of the track.
        ///</summary>
        [JsonPropertyName("href")]
        public string Href { get; set; }

        ///<summary>
        /// The Spotify ID for the track.
        ///</summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        ///<summary>
        /// Part of the response when Track Relinking is applied. If true , the track is playable 
        /// in the given market. Otherwise false.
        ///</summary>
        [JsonPropertyName("is_playable")]
        public bool IsPlayable { get; set; }

        ///<summary>
        /// Whether or not the track is from a local file.
        ///</summary>
        [JsonPropertyName("is_local")]
        public bool IsLocal { get; set; }

        ///<summary>
        /// The name of the track.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        ///<summary>
        /// The popularity of the track. The value will be between 0 and 100, with 100 being the most popular.
        ///</summary>
        [JsonPropertyName("popularity")]
        public int Popularity { get; set; }

        ///<summary>
        /// A link to a 30 second preview (MP3 format) of the track. Can be null
        ///</summary>
        [JsonPropertyName("preview_url")]
        public string PreviewUrl { get; set; }

        ///<summary>
        /// The number of the track. If an album has several discs, the track number is the number on the specified disc.
        ///</summary>
        [JsonPropertyName("track_number")]
        public int TrackNumber { get; set; }

        ///<summary>
        /// The object type: �track�.
        ///</summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        ///<summary>
        /// The Spotify URI for the track.
        ///</summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }

    public partial class VideoThumbnail
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public partial class ExternalIds
    {
        [JsonPropertyName("isrc")]
        public string Isrc { get; set; }
    }
}
