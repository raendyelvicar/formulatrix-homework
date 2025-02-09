// ReSharper disable All
using ObjectOrientedTest.Service.Interface;

namespace ObjectOrientedTest;

public class ObjectOrientedMain
{
    private readonly IRmService _rmService;
    public ObjectOrientedMain(IRmService rmService)
    {
        _rmService = rmService;
    }
    
    public async Task Register(string itemName, string itemContent, int itemType)
    {
        var id = await _rmService.Register(itemName, itemContent, itemType);
        Console.WriteLine($"Registering item: {id}");
    }

    public async Task Retrieve(string itemName)
    {
        var retrievedData =  await _rmService.Retrieve(itemName);
        Console.WriteLine($"Retrieved data: {retrievedData}");
    }

    public async Task GetType(string itemName)
    {
        var dataType = await _rmService.GetType(itemName);
        Console.WriteLine($"Data type: {dataType}");
    }

    public async Task Deregister(string itemName)
    {
        await _rmService.Deregister(itemName);
        Console.WriteLine($"Deregister {itemName}");
    }
}