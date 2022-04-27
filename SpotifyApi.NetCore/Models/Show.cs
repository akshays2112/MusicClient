using System;
using System.Text.Json.Serialization;

namespace SpotifyApi.NetCore
{
    /// <summary>
    /// Show object (full) (public)
    /// </summary>
    /// <remarks>
    /// https://developer.spotify.com/documentation/web-api/reference/object-model/#show-object-full
    /// </remarks>
    public partial class Show
    {
        /// <summary>
        /// A list of the countries in which the show can be played, identified by their ISO 3166-1 alpha-2 code.
        /// </summary>
        [JsonPropertyName("available_markets")]
        public string[] AvailableMarkets { get; set; }

        /// <summary>
        /// The copyright statements of the show.
        /// </summary>
        [JsonPropertyName("copyrights")]
        public object[] Copyrights { get; set; }

        /// <summary>
        /// A description of the show.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Whether or not the show has explicit content (true = yes it does; false = no it does not OR unknown).
        /// </summary>
        [JsonPropertyName("explicit")]
        public bool Explicit { get; set; }

        /// <summary>
        /// A list of the show’s episodes.
        /// </summary>
        [JsonPropertyName("episodes")]
        public PagedShows Episodes { get; set; }

        /// <summary>
        /// Known external URLs for this show.
        /// </summary>
        [JsonPropertyName("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full details of the show.
        /// </summary>
        [JsonPropertyName("href")]
        public Uri Href { get; set; }

        /// <summary>
        /// The Spotify ID for the show.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The cover art for the show in various sizes, widest first.
        /// </summary>
        [JsonPropertyName("images")]
        public Image[] Images { get; set; }

        /// <summary>
        /// True if all of the show’s episodes are hosted outside of Spotify’s CDN. This field might be null in some cases.
        /// </summary>
        [JsonPropertyName("is_externally_hosted")]
        public bool IsExternallyHosted { get; set; }

        /// <summary>
        /// A list of the languages used in the show, identified by their ISO 639 code.
        /// </summary>
        [JsonPropertyName("languages")]
        public string[] Languages { get; set; }

        /// <summary>
        /// The media type of the show.
        /// </summary>
        [JsonPropertyName("media_type")]
        public string MediaType { get; set; }

        /// <summary>
        /// The name of the show.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The publisher of the show.
        /// </summary>
        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }

        /// <summary>
        /// The object type: “show”.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The Spotify URI for the show.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }
}
