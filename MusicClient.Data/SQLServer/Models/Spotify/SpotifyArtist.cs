namespace MusicClient.Data.SQLServer.Models.Spotify
{
    public class SpotifyArtist
    {
        public int ID { get; set; }

        public string ArtistID { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public int Popularity { get; set; }

        public static SpotifyArtist NewSpotifyArtist(string artistId, string name, int popularity)
            => new SpotifyArtist { ArtistID = artistId, Name = name, Popularity = popularity };
    }
}
