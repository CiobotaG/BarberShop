using BarberShop.Models;
using SQLite;

namespace BarberShop.Data
{
    public class AppointmentDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public AppointmentDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Appointment>().Wait();
            _database.CreateTableAsync<Haircuts>().Wait();
            _database.CreateTableAsync<ListHaircut>().Wait();

        }
        public Task<List<Appointment>> GetShopListsAsync() { return _database.Table<Appointment>().ToListAsync(); }
        public Task<Appointment> GetShopListAsync(int id) { return _database.Table<Appointment>().Where(i => i.ID == id).FirstOrDefaultAsync(); }
        public Task<int> SaveShopListAsync(Appointment slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else { return _database.InsertAsync(slist); }
        }
        public Task<int> DeleteShopListAsync(Appointment slist)
        {
            return _database.DeleteAsync(slist);
        }
        public Task<int> SaveProductAsync(Haircuts haircut)
        {
            if (haircut.ID != 0)
            {
                return _database.UpdateAsync(haircut);
            }
            else
            {
                return _database.InsertAsync(haircut);
            }
        }
        public Task<int> DeleteProductAsync(Haircuts haircut)
        {
            return _database.DeleteAsync(haircut);
        }
        public Task<List<Haircuts>> GetProductsAsync()
        { return _database.Table<Haircuts>().ToListAsync(); }
        public Task<int> SaveListProductAsync(ListHaircut listp) { if (listp.ID != 0) { return _database.UpdateAsync(listp); } else { return _database.InsertAsync(listp); } }
        public Task<List<Haircuts>> GetListProductsAsync(int applistid)
        {
            return _database.QueryAsync<Haircuts>(
            "select H.ID, H.Description from Haircuts H"
            + " inner join ListHaircut LH"
            + " on H.ID = LH.HaircutID where LH.AppointmentID = ?",
            applistid);
        }
    }
}
