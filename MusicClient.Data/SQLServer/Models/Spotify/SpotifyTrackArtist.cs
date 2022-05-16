namespace MusicClient.Data.SQLServer.Models.Spotify
{
    public class SpotifyTrackArtist
    {
        public int ID { get; set; }

        public int TrackID { get; set; }

        public int ArtistID { get; set; }

        public static SpotifyTrackArtist NewSpotifyTrackArtist(int trackId, int artistId)
            => new SpotifyTrackArtist { TrackID = trackId, ArtistID = artistId };
    }
}
