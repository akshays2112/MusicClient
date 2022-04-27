namespace MusicClient.Data.SQLServer.Models.Spotify
{
    public class SpotifyAlbum
    {
        public int ID { get; set; }

        public string AlbumID { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public DateTime ReleaseDate { get; set; }

        public static SpotifyAlbum NewSpotifyAlbum(string albumId, string name, DateTime releaseDate)
        {
            SpotifyAlbum spotifyAlbum = new SpotifyAlbum();
            spotifyAlbum.AlbumID = albumId;
            spotifyAlbum.Name = name;
            spotifyAlbum.ReleaseDate = releaseDate;
            return spotifyAlbum;
        }
    }
}
