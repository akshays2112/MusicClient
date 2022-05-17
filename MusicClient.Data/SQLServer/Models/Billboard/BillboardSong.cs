namespace MusicClient.Data.SQLServer.Models.Billboard
{
    public class BillboardSong
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ArtistName { get; set; } = string.Empty;

        public DateTime SongDateOnly { get; set; }
    }
}
