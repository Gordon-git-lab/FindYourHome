using SQLite;
using System.IO;
using System.Threading.Tasks;
using FindYourHome.Models;
using System.Collections.Generic;

namespace FindYourHome.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection db;

        public DatabaseService(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<House>().Wait();
        }

        public Task<List<House>> GetHousesAsync() => db.Table<House>().ToListAsync();
        public Task<int> AddHouseAsync(House h) => db.InsertAsync(h);
        public Task<int> UpdateHouseAsync(House h) => db.UpdateAsync(h);
        public Task<int> DeleteHouseAsync(House h) => db.DeleteAsync(h);
    }
}
