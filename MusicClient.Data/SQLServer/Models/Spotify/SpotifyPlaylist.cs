namespace MusicClient.Data.SQLServer.Models.Spotify
{
    public class SpotifyPlaylist
    {
        public int ID { get; set; }

        public string PlaylistID { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public static SpotifyPlaylist NewSpotifyPlaylist(string playlistID, string name) 
        {
            SpotifyPlaylist spotifyPlaylist = new SpotifyPlaylist();
            spotifyPlaylist.PlaylistID = playlistID;
            spotifyPlaylist.Name = name;
            return spotifyPlaylist;
        }

        public static bool CheckForExistingSpotifyPlaylist(List<SpotifyPlaylist> listSpotifyPlaylists, string id)
        {
            return listSpotifyPlaylists.Find(p => p.PlaylistID == id) != null;
        }
    }
}
