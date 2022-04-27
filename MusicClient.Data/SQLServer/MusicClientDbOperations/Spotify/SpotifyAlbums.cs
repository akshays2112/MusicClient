using MusicClient.Data.SQLServer.Models.Spotify;

namespace MusicClient.Data.SQLServer.MusicClientDbOperations.Spotify
{
    public class SpotifyAlbums
    {
        private readonly MusicClientDBContext mcdbc = new();

        public IEnumerable<SpotifyAlbum>? GetAllSpotifyAlbums()
        {
            try
            {
                return mcdbc.SpotifyAlbums?.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new SpotifyAlbum
        public void AddSpotifyAlbum(SpotifyAlbum SpotifyAlbum)
        {
            try
            {
                mcdbc.SpotifyAlbums?.Add(SpotifyAlbum);
                mcdbc.SaveChanges();
                Globals.PreloadedSpotifyAlbums.Add(SpotifyAlbum);
            }
            catch
            {
                throw;
            }
        }
        //To Update particular SpotifyAlbum
        public void UpdateSpotifyAlbum(SpotifyAlbum SpotifyAlbum)
        {
            try
            {
                mcdbc.Update(SpotifyAlbum);
                mcdbc.SaveChanges();
                int idx = Globals.PreloadedSpotifyAlbums.FindIndex(p => p.AlbumID == SpotifyAlbum.AlbumID);
                if (idx > -1)
                {
                    Globals.PreloadedSpotifyAlbums.RemoveAt(idx);
                    Globals.PreloadedSpotifyAlbums.Insert(idx, SpotifyAlbum);
                }
            }
            catch
            {
                throw;
            }
        }
        //Get the particular SpotifyAlbum
        public SpotifyAlbum? GetSpotifyAlbum(int id)
        {
            try
            {
                SpotifyAlbum? SpotifyAlbum = mcdbc.SpotifyAlbums?.Find(id);
                return SpotifyAlbum;
            }
            catch
            {
                throw;
            }
        }
        //To Delete particular SpotifyAlbum
        public void DeleteSpotifyAlbum(int id)
        {
            try
            {
                SpotifyAlbum? SpotifyAlbum = mcdbc.SpotifyAlbums?.Find(id);
                if (SpotifyAlbum != null)
                {
                    mcdbc.Remove(SpotifyAlbum);
                    mcdbc.SaveChanges();
                    Globals.PreloadedSpotifyAlbums.Remove(SpotifyAlbum);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
