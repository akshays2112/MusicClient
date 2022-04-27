using System.Text.Json.Serialization;

namespace SpotifyApi.NetCore
{
    /// <summary>
    /// Category object (full)
    /// </summary>
    /// <remarks> https://developer.spotify.com/documentation/web-api/reference/browse/get-category/#categoryobject </remarks>
    public partial class Category
    {
        /// <summary>
        /// A link to the Web API endpoint returning full details of the category.
        /// </summary>
        [JsonPropertyName("href")]
        public string Href { get; set; }

        /// <summary>
        /// The category icon, in various sizes.
        /// </summary>
        [JsonPropertyName("icons")]
        public Image[] Icons { get; set; }

        /// <summary>
        /// The Spotify category ID of the category.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the category.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
