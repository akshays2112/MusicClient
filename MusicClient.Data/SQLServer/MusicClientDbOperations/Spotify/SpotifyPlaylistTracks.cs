using MusicClient.Data.SQLServer.Models.Spotify;
using static MusicClient.Data.Globals;

namespace MusicClient.Data.SQLServer.MusicClientDbOperations.Spotify
{
    public class SpotifyPlaylistTracks
    {
        private readonly MusicClientDBContext mcdbc = new();

        public IEnumerable<SpotifyPlaylistTrack>? GetAllSpotifyPlaylistTracks()
        {
            try
            {
                return mcdbc.SpotifyPlaylistTracks?.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new SpotifyPlaylistTrack
        public void AddSpotifyPlaylistTrack(SpotifyPlaylistTrack SpotifyPlaylistTrack)
        {
            try
            {
                mcdbc.SpotifyPlaylistTracks?.Add(SpotifyPlaylistTrack);
                mcdbc.SaveChanges();
                PreloadedSpotifyPlaylistTracks.Add(SpotifyPlaylistTrack);
            }
            catch
            {
                throw;
            }
        }
        //To Update particular SpotifyPlaylistTrack
        public void UpdateSpotifyPlaylistTrack(SpotifyPlaylistTrack SpotifyPlaylistTrack)
        {
            try
            {
                mcdbc.Update(SpotifyPlaylistTrack);
                mcdbc.SaveChanges();
                int idx = PreloadedSpotifyPlaylistTracks.FindIndex(
                    pt => pt.PlaylistID == SpotifyPlaylistTrack.PlaylistID &&
                        pt.TrackID == SpotifyPlaylistTrack.TrackID);
                if (idx > -1)
                {
                    PreloadedSpotifyPlaylistTracks.RemoveAt(idx);
                    PreloadedSpotifyPlaylistTracks.Insert(idx, SpotifyPlaylistTrack);
                }
            }
            catch
            {
                throw;
            }
        }
        //Get the particular SpotifyPlaylistTrack
        public SpotifyPlaylistTrack? GetSpotifyPlaylistTrack(int id)
        {
            try
            {
                SpotifyPlaylistTrack? SpotifyPlaylistTrack = mcdbc.SpotifyPlaylistTracks?.Find(id);
                return SpotifyPlaylistTrack;
            }
            catch
            {
                throw;
            }
        }
        //To Delete particular SpotifyPlaylistTrack
        public void DeleteSpotifyPlaylistTrack(int id)
        {
            try
            {
                SpotifyPlaylistTrack? SpotifyPlaylistTrack = mcdbc.SpotifyPlaylistTracks?.Find(id);
                if (SpotifyPlaylistTrack != null)
                {
                    mcdbc.Remove(SpotifyPlaylistTrack);
                    mcdbc.SaveChanges();
                    PreloadedSpotifyPlaylistTracks.Remove(SpotifyPlaylistTrack);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
