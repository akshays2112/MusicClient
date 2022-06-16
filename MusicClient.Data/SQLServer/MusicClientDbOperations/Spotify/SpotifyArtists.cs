using MusicClient.Data.SQLServer.Models.Spotify;
using static MusicClient.Data.Globals;

namespace MusicClient.Data.SQLServer.MusicClientDbOperations.Spotify
{
    public class SpotifyArtists
    {
        private readonly MusicClientDBContext mcdbc = new();

        public IEnumerable<SpotifyArtist>? GetAllSpotifyArtists()
        {
            try
            {
                return mcdbc.SpotifyArtists?.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new SpotifyArtist
        public void AddSpotifyArtist(SpotifyArtist SpotifyArtist)
        {
            try
            {
                mcdbc.SpotifyArtists?.Add(SpotifyArtist);
                mcdbc.SaveChanges();
                PreloadedSpotifyArtists.Add(SpotifyArtist);
            }
            catch
            {
                throw;
            }
        }
        //To Update particular SpotifyArtist
        public void UpdateSpotifyArtist(SpotifyArtist SpotifyArtist)
        {
            try
            {
                mcdbc.Update(SpotifyArtist);
                mcdbc.SaveChanges();
                int idx = PreloadedSpotifyArtists.FindIndex(p => p.ArtistID == SpotifyArtist.ArtistID);
                if (idx > -1)
                {
                    PreloadedSpotifyArtists.RemoveAt(idx);
                    PreloadedSpotifyArtists.Insert(idx, SpotifyArtist);
                }
            }
            catch
            {
                throw;
            }
        }
        //Get the particular SpotifyArtist
        public SpotifyArtist? GetSpotifyArtist(int id)
        {
            try
            {
                SpotifyArtist? SpotifyArtist = mcdbc.SpotifyArtists?.Find(id);
                return SpotifyArtist;
            }
            catch
            {
                throw;
            }
        }
        //To Delete particular SpotifyArtist
        public void DeleteSpotifyArtist(int id)
        {
            try
            {
                SpotifyArtist? SpotifyArtist = mcdbc.SpotifyArtists?.Find(id);
                if (SpotifyArtist != null)
                {
                    mcdbc.Remove(SpotifyArtist);
                    mcdbc.SaveChanges();
                    PreloadedSpotifyArtists.Remove(SpotifyArtist);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
