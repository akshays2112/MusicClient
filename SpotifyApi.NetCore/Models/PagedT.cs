using System.Text.Json.Serialization;

namespace SpotifyApi.NetCore
{
    public class Paged<T>
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("items")]
        public T[] Items { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("previous")]
        public string Previous { get; set; }

        /// <summary>
        /// The cursors used to find the next set of items.
        /// </summary>
        [JsonPropertyName("cursors")]
        public Cursors Cursors { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
