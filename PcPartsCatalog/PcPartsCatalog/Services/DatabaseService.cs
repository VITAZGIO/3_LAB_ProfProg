using SQLite;
using PcPartsCatalog.Models;

namespace PcPartsCatalog.Services;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection _database;

    public DatabaseService()
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "pcparts.db");

        _database = new SQLiteAsyncConnection(dbPath);

        _database.CreateTableAsync<PcPart>().Wait();
    }

    public Task<List<PcPart>> GetPartsAsync()
    {
        return _database.Table<PcPart>().ToListAsync();
    }

    public Task<int> SavePartAsync(PcPart part)
    {
        if (part.Id != 0)
        {
            return _database.UpdateAsync(part);
        }

        return _database.InsertAsync(part);
    }

    public Task<int> DeletePartAsync(PcPart part)
    {
        return _database.DeleteAsync(part);
    }

    public Task<int> DeleteAllPartsAsync()
    {
        return _database.DeleteAllAsync<PcPart>();
    }
}