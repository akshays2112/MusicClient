using WebApis.Net6.Spotify.Models;

namespace WebApis.Net6.Spotify
{
    public static class Globals
    {
        public const string ApiUrl = "https://api.spotify.com/v1";

        public static string? AccessToken { get; set; }

        #region Enums

        public enum ArtistOrUser { artist, user }

        public enum ArtistsOrTracks { artists, tracks }

        public enum TimeRanges { long_term, medium_term, short_term }

        #endregion
    }
}
