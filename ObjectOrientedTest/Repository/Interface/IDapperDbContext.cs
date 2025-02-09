using System.Data;

namespace ObjectOrientedTest.Repository.Interface;

public interface IDapperDbContext
{
    IDbConnection  GetConnection();
}