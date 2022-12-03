using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using AppConselheiro.Model;
using System.Threading.Tasks;

namespace AppConselheiro.Helper
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _db;


        public SQLiteDatabaseHelper(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Conselho>().Wait();
        }


        public Task<List<Conselho>> GetAllConselhos()
        {
            return _db.Table<Conselho>().OrderByDescending(i => i.Id).ToListAsync();
        }


        public Task<Conselho> InsertConselho(Conselho c)
        {
            _db.InsertAsync(c);

            return _db.Table<Conselho>().OrderByDescending(i => i.Id).FirstOrDefaultAsync();
        }


        public Task<Conselho> GetConselhoById(int id)
        {
            return _db.Table<Conselho>().FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}