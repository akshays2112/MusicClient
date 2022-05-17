namespace WebApis.Net6.Spotify
{
    public static class Globals
    {
        public const string ApiUrl = "https://api.spotify.com/v1";

        public enum AlbumType { album, single, compilation }
        public enum ReleaseDatePrecision { year, month, day }

        public enum ObjectType { album, artist, show, episode, track, user }

        public enum CopyrightType { C, P }
    }
}
