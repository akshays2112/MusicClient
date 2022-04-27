﻿using System.Text.Json.Serialization;

namespace SpotifyApi.NetCore
{
    public class Actions
    {
        [JsonPropertyName("disallows")]
        public Disallows Disallows { get; set; }
    }

    public class Disallows
    {
        [JsonPropertyName("interrupting_playback")]
        public bool InterruptingPlayback { get; set; }

        [JsonPropertyName("pausing")]
        public bool Pausing { get; set; }

        [JsonPropertyName("resuming")]
        public bool Resuming { get; set; }

        [JsonPropertyName("seeking")]
        public bool Seeking { get; set; }

        [JsonPropertyName("skipping_next")]
        public bool SkippingNext { get; set; }

        [JsonPropertyName("skipping_prev")]
        public bool SkippingPrev { get; set; }

        [JsonPropertyName("toggling_repeat_context")]
        public bool TogglingRepeatContext { get; set; }

        [JsonPropertyName("toggling_shuffle")]
        public bool TogglingShuffle { get; set; }

        [JsonPropertyName("toggling_repeat_track")]
        public bool TogglingRepeatTrack { get; set; }

        [JsonPropertyName("transferring_playback")]
        public bool TransferringPlayback { get; set; }
    }
}
