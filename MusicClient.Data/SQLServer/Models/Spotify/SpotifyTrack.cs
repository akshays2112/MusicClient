namespace MusicClient.Data.SQLServer.Models.Spotify
{
    public class SpotifyTrack
    {
        public int ID { get; set; }

        public string TrackID { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public int Popularity { get; set; }

        public static SpotifyTrack NewSpotifyTrack(string trackId, string name, int popularity)
        {
            SpotifyTrack spotifyTrack = new SpotifyTrack();
            spotifyTrack.TrackID = trackId;
            spotifyTrack.Name = name;
            spotifyTrack.Popularity = popularity;
            return spotifyTrack;
        }

        public static bool CheckForExistingSpotifyTrack(List<SpotifyTrack> listSpotifyTracks, string id)
        {
            return listSpotifyTracks.Find(t => t.TrackID == id) != null;
        }
    }
}
