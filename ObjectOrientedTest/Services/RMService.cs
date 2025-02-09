// ReSharper disable All
using ObjectOrientedTest.Helpers;
using ObjectOrientedTest.Repository.Interface;
using ObjectOrientedTest.Service.Interface;

namespace ObjectOrientedTest.Services;

public class RmService : IRmService
{
    private readonly IRepositoryManager _repositoryManager;
    
    public RmService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<string> Register(string itemName, string itemContent, int itemType)
    {
        if(itemType == 2 && !FormatValidation.IsValidXml(itemContent)) throw new FormatException("Invalid item content");
        else if(itemType == 1 && !FormatValidation.IsValidJson(itemContent)) throw new FormatException("Invalid item content"); 
        return await _repositoryManager.Register(itemName, itemContent, itemType);
    }

    public async Task<string?> Retrieve(string itemName)
    {
        return await _repositoryManager.Retrieve(itemName);
    }

    public async Task<int> GetType(string itemName)
    {
        return await _repositoryManager.GetType(itemName);
    }

    public async Task Deregister(string itemName)
    {
        await _repositoryManager.Deregister(itemName);
    }
    
}