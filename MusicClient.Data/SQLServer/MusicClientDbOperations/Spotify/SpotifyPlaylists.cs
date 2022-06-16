using MusicClient.Data.SQLServer.Models.Spotify;
using static MusicClient.Data.Globals;

namespace MusicClient.Data.SQLServer.MusicClientDbOperations.Spotify
{
    public class SpotifyPlaylists
    {
        private readonly MusicClientDBContext mcdbc = new();

        public IEnumerable<SpotifyPlaylist>? GetAllSpotifyPlaylists()
        {
            try
            {
                return mcdbc.SpotifyPlaylists?.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new SpotifyPlaylist
        public void AddSpotifyPlaylist(SpotifyPlaylist SpotifyPlaylist)
        {
            try
            {
                mcdbc.SpotifyPlaylists?.Add(SpotifyPlaylist);
                mcdbc.SaveChanges();
                PreloadedSpotifyPlaylists.Add(SpotifyPlaylist);
            }
            catch
            {
                throw;
            }
        }
        //To Update particular SpotifyPlaylist
        public void UpdateSpotifyPlaylist(SpotifyPlaylist SpotifyPlaylist)
        {
            try
            {
                mcdbc.Update(SpotifyPlaylist);
                mcdbc.SaveChanges();
                int idx = PreloadedSpotifyPlaylists.FindIndex(p => p.PlaylistID == SpotifyPlaylist.PlaylistID);
                if (idx > -1)
                {
                    PreloadedSpotifyPlaylists.RemoveAt(idx);
                    PreloadedSpotifyPlaylists.Insert(idx, SpotifyPlaylist);
                }
            }
            catch
            {
                throw;
            }
        }
        //Get the particular SpotifyPlaylist
        public SpotifyPlaylist? GetSpotifyPlaylist(int id)
        {
            try
            {
                SpotifyPlaylist? SpotifyPlaylist = mcdbc.SpotifyPlaylists?.Find(id);
                return SpotifyPlaylist;
            }
            catch
            {
                throw;
            }
        }
        //To Delete particular SpotifyPlaylist
        public void DeleteSpotifyPlaylist(int id)
        {
            try
            {
                SpotifyPlaylist? SpotifyPlaylist = mcdbc.SpotifyPlaylists?.Find(id);
                if (SpotifyPlaylist != null)
                {
                    mcdbc.Remove(SpotifyPlaylist);
                    mcdbc.SaveChanges();
                    PreloadedSpotifyPlaylists.Remove(SpotifyPlaylist);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
