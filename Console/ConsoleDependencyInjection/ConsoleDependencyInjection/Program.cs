// See https://aka.ms/new-console-template for more information
//https://keestalkstech.com/2018/04/dependency-injection-with-ioptions-in-console-apps-in-net-core-2/
using ConsoleDependencyInjection;
using ConsoleDependencyInjection.Models;
using ConsoleDependencyInjection.Services;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection();

// using extension methods

services.ConfigureServices();

var serviceProvider = services.BuildServiceProvider();

var taskService = serviceProvider.GetService<TaskService>();
await taskService.ExecuteAsync();

var todo1 = new Todo()
{
    Id = 1,
    Name = "Test"
};

var todo2 = new Todo()
{
    Id = 1,
    Name = "Test "
};

Console.WriteLine(todo1 == todo2);

