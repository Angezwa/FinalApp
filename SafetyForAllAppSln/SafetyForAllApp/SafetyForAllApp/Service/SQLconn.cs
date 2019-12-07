using SafetyForAllApp.Model;
using SafetyForAllApp.Service.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SafetyForAllApp.MyDatabase
{
    public class SQLconn : IDatabase
    {
        private SQLiteAsyncConnection database;

        
        public SQLconn()
        {
            string dbPath = GetDbPath();

            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<SignUpDetails>().Wait();
        }

        private string GetDbPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Safety.Db3");
        }
        public Task<List<SignUpDetails>> GetItemsAsync()
        {
            return database.Table<SignUpDetails>().ToListAsync();
        }

        public Task<List<SignUpDetails>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<SignUpDetails>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<SignUpDetails> GetItemAsync(int id)
        {
            return database.Table<SignUpDetails>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(SignUpDetails item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(SignUpDetails item)
        {
            return database.DeleteAsync(item);
        }

        public async Task<SignUpDetails> GetUserByUserName(string userName)
        {
            return await database.Table<SignUpDetails>().Where(x => x.Username == userName).FirstOrDefaultAsync();
        }
    }
}
