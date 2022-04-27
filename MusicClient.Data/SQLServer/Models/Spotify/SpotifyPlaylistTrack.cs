using System.ComponentModel.DataAnnotations;

namespace MusicClient.Data.SQLServer.Models.Spotify
{
    public class SpotifyPlaylistTrack
    {
        public int ID { get; set; }

        public int PlaylistID { get; set; }

        public int TrackID { get; set; }

        public static SpotifyPlaylistTrack NewSpotifyPlaylistTrack(int playlistId, int trackId)
        {
            SpotifyPlaylistTrack spotifyPlaylistTrack = new SpotifyPlaylistTrack();
            spotifyPlaylistTrack.PlaylistID = playlistId;
            spotifyPlaylistTrack.TrackID = trackId;
            return spotifyPlaylistTrack;
        }
    }
}
