﻿using System.Text.Json.Serialization;

namespace WebApis.Net6.Spotify.Models
{
    public class Restriction
    {
        [JsonPropertyName("reason")]
        public string Reason { get; set; } = string.Empty;
    }
}
