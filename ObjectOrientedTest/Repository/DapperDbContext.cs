//Reference: https://medium.com/@siyahkut/using-dapper-with-dbcontext-9c263a1d1d90

using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ObjectOrientedTest.Repository.Interface;

namespace ObjectOrientedTest.Repository;

public class DapperDbContext : IDapperDbContext
{
    private readonly string? _connectionString;

    public DapperDbContext()
    {
        _connectionString = "user ID=formulatrix_user;Password=mysecretpassword;Host=localhost;Port=5432;Database=formulatrix_db";

        if (string.IsNullOrEmpty(_connectionString))
        {
            throw new InvalidOperationException("Database connection string is not set.");
        }
    }

    public IDbConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
