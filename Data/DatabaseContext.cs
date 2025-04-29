using System.Data.SqlTypes;

namespace Inventory_Management_System.Data;
using Inventory_Management_System.Models;
using SQLite;

public class DatabaseContext
{
    private readonly SQLiteAsyncConnection _database;

    public DatabaseContext(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Item>().Wait();
    }

    public Task<List<Item>> GetItemsAsync() => _database.Table<Item>().ToListAsync();
    public Task<int> SaveItemAsync(Item item) => _database.InsertAsync(item);
}