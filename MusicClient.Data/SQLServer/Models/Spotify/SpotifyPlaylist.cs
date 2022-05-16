namespace MusicClient.Data.SQLServer.Models.Spotify
{
    public class SpotifyPlaylist
    {
        public int ID { get; set; }

        public string PlaylistID { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public static SpotifyPlaylist NewSpotifyPlaylist(string playlistID, string name)
            => new SpotifyPlaylist { PlaylistID = playlistID, Name = name };

        public static bool CheckForExistingSpotifyPlaylist(List<SpotifyPlaylist> listSpotifyPlaylists, string id)
            => listSpotifyPlaylists.Find(p => p.PlaylistID == id) != null;

        public static bool CheckForExistingSpotifyPlaylistName(List<SpotifyPlaylist> listSpotifyPlaylists, string playlistName)
            => listSpotifyPlaylists.Find(p => p.Name == playlistName) != null;
    }
}
