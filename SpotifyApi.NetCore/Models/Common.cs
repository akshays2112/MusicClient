using System.Text.Json.Serialization;

namespace SpotifyApi.NetCore
{
    /// <summary>
    /// External URL object
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/object-model/#external-url-object
    /// </remarks>
    public partial class ExternalUrls
    {
        [JsonPropertyName("spotify")]
        public string Spotify { get; set; }
    }

    /// <summary>
    /// Followers object
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/object-model/#followers-object
    /// </remarks>
    public partial class Followers
    {
        /// <summary>
        /// A link to the Web API endpoint providing full details of the followers; null if not available.
        /// </summary>
        [JsonPropertyName("href")]
        public string Href { get; set; }

        /// <summary>
        /// The total number of followers.
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }

    /// <summary>
    /// Image object
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/object-model/#image-object
    /// </remarks>
    public partial class Image
    {
        /// <summary>
        /// The image height in pixels. If unknown: null or not returned.
        /// </summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }

        /// <summary>
        /// The source URL of the image.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// The image width in pixels. If unknown: null or not returned.
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }
    }

    /// <summary>
    /// User object (public)
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/object-model/#user-object-public
    /// </remarks>
    public partial class User
    {
        /// <summary>
        /// The country of the user, as set in the user's account profile. An ISO 3166-1 alpha-2 country 
        /// code. This field is only available when the current user has granted access to the 
        /// user-read-private scope.
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// The name displayed on the user’s profile. null if not available.
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The user's email address, as entered by the user when creating their account. Important! 
        /// This email address is unverified; there is no proof that it actually belongs to the user. 
        /// This field is only available when the current user has granted access to the user-read-email 
        /// scope.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Known public external URLs for this user.
        /// </summary>
        [JsonPropertyName("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }

        /// <summary>
        /// Information about the followers of this user.
        /// </summary>
        [JsonPropertyName("followers")]
        public Followers Followers { get; set; }

        /// <summary>
        /// A link to the Web API endpoint for this user.
        /// </summary>
        [JsonPropertyName("href")]
        public string Href { get; set; }

        /// <summary>
        /// The Spotify user ID for this user.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The user’s profile image.
        /// </summary>
        [JsonPropertyName("images")]
        public Image[] Images { get; set; }

        /// <summary>
        /// The user's Spotify subscription level: "premium", "free", etc. (The subscription level 
        /// "open" can be considered the same as "free".) This field is only available when the 
        /// current user has granted access to the user-read-private scope.
        /// </summary>
        [JsonPropertyName("product")]
        public string Product { get; set; }

        /// <summary>
        /// The object type: "user"
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The Spotify URI for this user.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// Resume Point object (public)
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/object-model/#resume-point-object
    /// </remarks>
    public partial class ResumePoint
    {
        /// <summary>
        /// Whether or not the episode has been fully played by the user.
        /// </summary>
        [JsonPropertyName("fully_played")]
        public bool FullyPlayed { get; set; }

        /// <summary>
        /// The user’s most recent position in the episode in milliseconds.
        /// </summary>
        [JsonPropertyName("resume_position_ms")]
        public long ResumePositionMs { get; set; }
    }
}