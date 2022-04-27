using MusicClient.Data.SQLServer.Models.Spotify;

namespace MusicClient.Data.SQLServer.MusicClientDbOperations.Spotify
{
    public class SpotifyTracks
    {
        private readonly MusicClientDBContext mcdbc = new();

        public IEnumerable<SpotifyTrack>? GetAllSpotifyTracks()
        {
            try
            {
                return mcdbc.SpotifyTracks?.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new SpotifyTrack
        public void AddSpotifyTrack(SpotifyTrack SpotifyTrack)
        {
            try
            {
                mcdbc.SpotifyTracks?.Add(SpotifyTrack);
                mcdbc.SaveChanges();
                Globals.PreloadedSpotifyTracks.Add(SpotifyTrack);
            }
            catch
            {
                throw;
            }
        }
        //To Update particular SpotifyTrack
        public void UpdateSpotifyTrack(SpotifyTrack SpotifyTrack)
        {
            try
            {
                mcdbc.Update(SpotifyTrack);
                mcdbc.SaveChanges();
                int idx = Globals.PreloadedSpotifyTracks.FindIndex(p => p.TrackID == SpotifyTrack.TrackID);
                if (idx > -1)
                {
                    Globals.PreloadedSpotifyTracks.RemoveAt(idx);
                    Globals.PreloadedSpotifyTracks.Insert(idx, SpotifyTrack);
                }
            }
            catch
            {
                throw;
            }
        }
        //Get the particular SpotifyTrack
        public SpotifyTrack? GetSpotifyTrack(int id)
        {
            try
            {
                SpotifyTrack? SpotifyTrack = mcdbc.SpotifyTracks?.Find(id);
                return SpotifyTrack;
            }
            catch
            {
                throw;
            }
        }
        public int? GetSpotifyTrack(string spotifyTrackId)
        {
            try
            {
                if (mcdbc.SpotifyTracks is not null)
                {
                    foreach (SpotifyTrack spotifyTrack in mcdbc.SpotifyTracks)
                    {
                        if(spotifyTrack.TrackID == spotifyTrackId)
                        {
                            return spotifyTrack.ID;
                        }
                    }
                }
                return null;
            }
            catch
            {
                throw;
            }
        }
        //To Delete particular SpotifyTrack
        public void DeleteSpotifyTrack(int id)
        {
            try
            {
                SpotifyTrack? SpotifyTrack = mcdbc.SpotifyTracks?.Find(id);
                if (SpotifyTrack != null)
                {
                    mcdbc.Remove(SpotifyTrack);
                    mcdbc.SaveChanges();
                    Globals.PreloadedSpotifyTracks.Remove(SpotifyTrack);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
