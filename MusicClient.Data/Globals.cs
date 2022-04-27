using MusicClient.Data.SQLServer.Models.Spotify;
using MusicClient.Data.SQLServer.MusicClientDbOperations.Spotify;

namespace MusicClient.Data
{
    public static class Globals
    {
        //Specifically for releaseDate only having the year some mistake in the spotify database or api json return more likely or json parsing less likely
        public static DateTime ConvertToDatetime(string? strDate)
        {
            try
            {
                return Convert.ToDateTime(strDate);
            }
            catch
            {
                DateTime dt = new DateTime(Convert.ToInt32(strDate), 1, 1);
                return dt;
            }
        }

        public static List<SpotifyPlaylist> PreloadedSpotifyPlaylists = (new SpotifyPlaylists()).GetAllSpotifyPlaylists()?.ToList() ?? new();

        public static List<SpotifyTrack> PreloadedSpotifyTracks = (new SpotifyTracks()).GetAllSpotifyTracks()?.ToList() ?? new();

        public static List<SpotifyArtist> PreloadedSpotifyArtists = (new SpotifyArtists()).GetAllSpotifyArtists()?.ToList() ?? new();

        public static List<SpotifyAlbum> PreloadedSpotifyAlbums = (new SpotifyAlbums()).GetAllSpotifyAlbums()?.ToList() ?? new();


        public static List<SpotifyPlaylistTrack> PreloadedSpotifyPlaylistTracks = (new SpotifyPlaylistTracks()).GetAllSpotifyPlaylistTracks()?.ToList() ?? new();

        public static List<SpotifyTrackArtist> PreloadedSpotifyTrackArtists = (new SpotifyTrackArtists()).GetAllSpotifyTrackArtists()?.ToList() ?? new();

        public static List<SpotifyTrackAlbum> PreloadedSpotifyTrackAlbums = (new SpotifyTrackAlbums()).GetAllSpotifyTrackAlbums()?.ToList() ?? new();
    }
}
