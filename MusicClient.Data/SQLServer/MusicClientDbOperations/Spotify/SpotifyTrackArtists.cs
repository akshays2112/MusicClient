using static MusicClient.Data.Globals;
using MusicClient.Data.SQLServer.Models.Spotify;

namespace MusicClient.Data.SQLServer.MusicClientDbOperations.Spotify
{
    public class SpotifyTrackArtists
    {
        private readonly MusicClientDBContext mcdbc = new();

        public IEnumerable<SpotifyTrackArtist>? GetAllSpotifyTrackArtists()
        {
            try
            {
                return mcdbc.SpotifyTrackArtists?.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new SpotifyTrackArtist
        public void AddSpotifyTrackArtist(SpotifyTrackArtist SpotifyTrackArtist)
        {
            try
            {
                mcdbc.SpotifyTrackArtists?.Add(SpotifyTrackArtist);
                mcdbc.SaveChanges();
                PreloadedSpotifyTrackArtists.Add(SpotifyTrackArtist);
            }
            catch
            {
                throw;
            }
        }
        //To Update particular SpotifyTrackArtist
        public void UpdateSpotifyTrackArtist(SpotifyTrackArtist SpotifyTrackArtist)
        {
            try
            {
                mcdbc.Update(SpotifyTrackArtist);
                mcdbc.SaveChanges();
                int idx = PreloadedSpotifyTrackArtists.FindIndex(
                    pt => pt.ArtistID == SpotifyTrackArtist.ArtistID &&
                        pt.TrackID == SpotifyTrackArtist.TrackID);
                if (idx > -1)
                {
                    PreloadedSpotifyTrackArtists.RemoveAt(idx);
                    PreloadedSpotifyTrackArtists.Insert(idx, SpotifyTrackArtist);
                }
            }
            catch
            {
                throw;
            }
        }
        //Get the particular SpotifyTrackArtist
        public SpotifyTrackArtist? GetSpotifyTrackArtist(int id)
        {
            try
            {
                SpotifyTrackArtist? SpotifyTrackArtist = mcdbc.SpotifyTrackArtists?.Find(id);
                return SpotifyTrackArtist;
            }
            catch
            {
                throw;
            }
        }
        //To Delete particular SpotifyTrackArtist
        public void DeleteSpotifyTrackArtist(int id)
        {
            try
            {
                SpotifyTrackArtist? SpotifyTrackArtist = mcdbc.SpotifyTrackArtists?.Find(id);
                if (SpotifyTrackArtist != null)
                {
                    mcdbc.Remove(SpotifyTrackArtist);
                    mcdbc.SaveChanges();
                    PreloadedSpotifyTrackArtists.Remove(SpotifyTrackArtist);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
