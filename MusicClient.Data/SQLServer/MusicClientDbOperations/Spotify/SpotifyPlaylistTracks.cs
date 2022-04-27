using MusicClient.Data.SQLServer.Models.Spotify;

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
                Globals.PreloadedSpotifyPlaylistTracks.Add(SpotifyPlaylistTrack);
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
                int idx = Globals.PreloadedSpotifyPlaylistTracks.FindIndex(
                    pt => pt.PlaylistID == SpotifyPlaylistTrack.PlaylistID &&
                        pt.TrackID == SpotifyPlaylistTrack.TrackID);
                if (idx > -1)
                {
                    Globals.PreloadedSpotifyPlaylistTracks.RemoveAt(idx);
                    Globals.PreloadedSpotifyPlaylistTracks.Insert(idx, SpotifyPlaylistTrack);
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
                    Globals.PreloadedSpotifyPlaylistTracks.Remove(SpotifyPlaylistTrack);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
