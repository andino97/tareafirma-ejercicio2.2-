using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tareafirma2_2.Model;
using SQLite;

namespace tareafirma2_2.Controller
{
    public class Database
    {
        readonly SQLiteAsyncConnection db;

        public Database (String pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);

            db.CreateTableAsync<firma>().Wait();
        }

        public Task<List<firma>> GetListfirma()
        {
            return db.Table<firma>().ToListAsync();
        }

        public Task<firma> GetfirmaByCode(int firmaCode)
        {
            return db.Table<firma>()
                .Where(i => i.code == firmaCode)
                .FirstOrDefaultAsync();
        }

        public Task<int> savefirma(firma firma)
        {
            return firma.code != 0 ? db.UpdateAsync(firma) : db.InsertAsync(firma);
        }

        public Task<int> deletefirma(firma firma)
        {
            return db.DeleteAsync(firma);
        }
    }
}
