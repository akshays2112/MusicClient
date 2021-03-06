using System.Text.Json.Serialization;

namespace SpotifyApi.NetCore
{
    ///<summary>
    /// recommendations object
    ///</summary>
    public partial class RecommendationsResult
    {
        ///<summary>
        /// An array of track object (simplified) ordered according to the parameters supplied.
        ///</summary>
        [JsonPropertyName("tracks")]
        public Track[] Tracks { get; set; }

        ///<summary>
        /// An array of recommendation seed objects.
        ///</summary>
        [JsonPropertyName("seeds")]
        public Seed[] Seeds { get; set; }
    }

    ///<summary>
    /// recommendations seed object
    ///</summary>
    public partial class Seed
    {
        ///<summary>
        /// The number of recommended tracks available for this seed.
        ///</summary>
        [JsonPropertyName("initialPoolSize")]
        public int InitialPoolSize { get; set; }

        ///<summary>
        /// The number of tracks available after min_* and max_* filters have been applied.
        ///</summary>
        [JsonPropertyName("afterFilteringSize")]
        public int AfterFilteringSize { get; set; }

        ///<summary>
        /// The number of tracks available after relinking for regional availability.
        ///</summary>
        [JsonPropertyName("afterRelinkingSize")]
        public int AfterRelinkingSize { get; set; }

        ///<summary>
        /// The id used to select this seed. This will be the same as the string used in the seed_artists, 
        /// seed_tracks or seed_genres parameter.
        ///</summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        ///<summary>
        /// The entity type of this seed. One of artist , track or genre.
        ///</summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        ///<summary>
        /// A link to the full track or artist data for this seed. For tracks this will be a link to 
        /// a Track Object. For artists a link to an Artist Object. For genre seeds, this value will 
        /// be null.
        ///</summary>
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
