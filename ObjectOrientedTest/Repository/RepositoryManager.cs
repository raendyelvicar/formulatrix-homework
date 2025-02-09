using System.Data;
using System.Text.Json;
using Dapper;
using Microsoft.Extensions.Configuration;
using ObjectOrientedTest.Repository.Interface;
// ReSharper disable All

namespace ObjectOrientedTest.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly IDapperDbContext _dbContext;

    public RepositoryManager(IDapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> Register(string itemName, string itemContent, int itemType)
    {
        var query = $@"INSERT INTO repository (id, itemName, itemContent, itemType)
                        VALUES (@id, @itemName, @itemContent, @itemType) 
                        RETURNING id;";
        using var conn = _dbContext.GetConnection();
        var id = Guid.NewGuid();
        await conn.QueryAsync(query, new { id, itemName, itemContent, itemType });
        return id.ToString();
    }

    public async Task<string> Retrieve(string itemName)
    {
        var query = $@"SELECT id, itemName, itemContent, itemType FROM repository WHERE itemName = @itemName;";
        using var conn = _dbContext.GetConnection();
        var data = await conn.QueryAsync<Models.Repository>(query, new { itemName });
        var parsedData = JsonSerializer.Serialize(data.FirstOrDefault());
        return parsedData;
    }

    public async Task<int> GetType(string itemName)
    {
        var query = $@"SELECT itemType FROM repository WHERE itemName = @itemName;";
        using var conn = _dbContext.GetConnection();
        var data = await conn.QueryAsync<int>(query, new { itemName });
        return data.FirstOrDefault();
    }

    public async Task Deregister(string itemName)
    {
        var query = $@"DELETE FROM repository WHERE itemName = @itemName;";
        using var conn = _dbContext.GetConnection();
        await conn.QueryAsync(query, new { itemName });
    }
}