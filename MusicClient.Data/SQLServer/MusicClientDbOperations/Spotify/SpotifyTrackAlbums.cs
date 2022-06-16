using MusicClient.Data.SQLServer.Models.Spotify;
using static MusicClient.Data.Globals;

namespace MusicClient.Data.SQLServer.MusicClientDbOperations.Spotify
{
    public class SpotifyTrackAlbums
    {
        private readonly MusicClientDBContext mcdbc = new();

        public IEnumerable<SpotifyTrackAlbum>? GetAllSpotifyTrackAlbums()
        {
            try
            {
                return mcdbc.SpotifyTrackAlbums?.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new SpotifyTrackAlbum
        public void AddSpotifyTrackAlbum(SpotifyTrackAlbum SpotifyTrackAlbum)
        {
            try
            {
                mcdbc.SpotifyTrackAlbums?.Add(SpotifyTrackAlbum);
                mcdbc.SaveChanges();
                PreloadedSpotifyTrackAlbums.Add(SpotifyTrackAlbum);
            }
            catch
            {
                throw;
            }
        }
        //To Update particular SpotifyTrackAlbum
        public void UpdateSpotifyTrackAlbum(SpotifyTrackAlbum SpotifyTrackAlbum)
        {
            try
            {
                mcdbc.Update(SpotifyTrackAlbum);
                mcdbc.SaveChanges();
                int idx = PreloadedSpotifyTrackAlbums.FindIndex(
                    pt => pt.AlbumID == SpotifyTrackAlbum.AlbumID &&
                        pt.TrackID == SpotifyTrackAlbum.TrackID);
                if (idx > -1)
                {
                    PreloadedSpotifyTrackAlbums.RemoveAt(idx);
                    PreloadedSpotifyTrackAlbums.Insert(idx, SpotifyTrackAlbum);
                }
            }
            catch
            {
                throw;
            }
        }
        //Get the particular SpotifyTrackAlbum
        public SpotifyTrackAlbum? GetSpotifyTrackAlbum(int id)
        {
            try
            {
                SpotifyTrackAlbum? SpotifyTrackAlbum = mcdbc.SpotifyTrackAlbums?.Find(id);
                return SpotifyTrackAlbum;
            }
            catch
            {
                throw;
            }
        }
        //To Delete particular SpotifyTrackAlbum
        public void DeleteSpotifyTrackAlbum(int id)
        {
            try
            {
                SpotifyTrackAlbum? SpotifyTrackAlbum = mcdbc.SpotifyTrackAlbums?.Find(id);
                if (SpotifyTrackAlbum != null)
                {
                    mcdbc.Remove(SpotifyTrackAlbum);
                    mcdbc.SaveChanges();
                    PreloadedSpotifyTrackAlbums.Remove(SpotifyTrackAlbum);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
