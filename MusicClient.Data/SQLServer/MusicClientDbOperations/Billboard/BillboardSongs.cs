using MusicClient.Data.SQLServer.Models.Billboard;

namespace MusicClient.Data.SQLServer.MusicClientDbOperations.Billboard
{
    public class BillboardSongs
    {
        private readonly MusicClientDBContext mcdbc = new();

        public IEnumerable<BillboardSong>? GetAllBillboardSongs()
        {
            try
            {
                return mcdbc.BillboardSongs?.ToList();
            }
            catch 
            {
                throw; 
            }
        }
        //To Add new BillboardSong
        public void AddBillboardSong(BillboardSong BillboardSong)
        {
            try
            {
                mcdbc.BillboardSongs?.Add(BillboardSong);
                mcdbc.SaveChanges();
            }
            catch 
            {
                throw; 
            }
        }
        //To Update particular BillboardSong
        public void UpdateBillboardSong(BillboardSong BillboardSong)
        {
            try
            {
                mcdbc.Update(BillboardSong);
                mcdbc.SaveChanges();
            }
            catch 
            { 
                throw; 
            }
        }
        //Get the particular BillboardSong
        public BillboardSong? GetBillboardSong(int id)
        {
            try
            {
                BillboardSong? BillboardSong = mcdbc.BillboardSongs?.Find(id);
                return BillboardSong;
            }
            catch
            {
                throw;
            }
        }
        //To Delete particular BillboardSong
        public void DeleteBillboardSong(int id)
        {
            try
            {
                BillboardSong? BillboardSong = mcdbc.BillboardSongs?.Find(id);
                if (BillboardSong != null)
                {
                    mcdbc.Remove(BillboardSong);
                    mcdbc.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
