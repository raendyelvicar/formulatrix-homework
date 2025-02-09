// See https://aka.ms/new-console-template for more information

using CodingCompetencyTest;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ObjectOrientedTest;
using ObjectOrientedTest.Repository;
using ObjectOrientedTest.Repository.Interface;
using ObjectOrientedTest.Service.Interface;
using ObjectOrientedTest.Services;

// START: Answer for Object Oriented Test
// Source: https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage
// Register services
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddSingleton<IDapperDbContext, DapperDbContext>();
builder.Services.AddSingleton<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IRmService, RmService>();


var app = builder.Build();
//
// var rmService = app.Services.GetRequiredService<IRmService>();
// var ooMain = new ObjectOrientedMain(rmService);
//
// await ooMain.GetType("Json File 4");
//
// //await ooMain.Retrieve("Json File 4");
//
//
// //await ooMain.Register("Json File 4","{\n    \"name\": \"James\",\n    \"age\": 22,\n    \"email\": \"james@example.com\"\n}\n", 1);
//
// await ooMain.Deregister("Json File 4");

//
//
// // END: Answer for Object Oriented Test
//
//

//START: Answer for Coding Competency Test
Main main = new Main();
//No 1
Console.WriteLine($"Result no.1: {main.CheckNum(15)}");

//No 2
Rules.AddRule(7, "jazz");
Console.WriteLine($"Result no.2: {main.CheckNum(15)}");

//No 3
Rules.AddRule(4, "baz");
Rules.AddRule(9, "huzz");
Console.WriteLine($"Result no.3: {main.CheckNum(15)}");
//END: Answer for Coding Competency Test