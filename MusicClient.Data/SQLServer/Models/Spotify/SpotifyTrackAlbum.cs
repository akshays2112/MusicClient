namespace MusicClient.Data.SQLServer.Models.Spotify
{
    public class SpotifyTrackAlbum
    {
        public int ID { get; set; }

        public int TrackID { get; set; }

        public int AlbumID { get; set; }

        public static SpotifyTrackAlbum NewSpotifyTrackAlbum(int trackId, int albumId)
            => new SpotifyTrackAlbum { TrackID = trackId, AlbumID = albumId };
    }
}
