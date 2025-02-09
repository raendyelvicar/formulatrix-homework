namespace ObjectOrientedTest.Repository.Interface;

public interface IRepositoryManager
{
    Task<string> Register(string itemName, string itemContent, int itemType);
    Task<string> Retrieve(string itemName);
    Task<int> GetType(string itemName);
    Task Deregister(string itemName);
}

