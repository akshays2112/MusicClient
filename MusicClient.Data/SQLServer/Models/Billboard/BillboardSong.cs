namespace MusicClient.Data.SQLServer.Models.Billboard
{
    public class BillboardSong
    {
        public int ID { get; set; }

        public string? Name { get; set; }

        public string? ArtistName { get; set; }

        public DateTime SongDateOnly { get; set; }
    }
}
