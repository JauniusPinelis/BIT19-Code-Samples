// See https://aka.ms/new-console-template for more information

using ConsoleDependencyInjection;
using ConsoleDependencyInjection.Services;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

var services = new ServiceCollection();

// using extension methods

services.ConfigureServices();

var serviceProvider = services.BuildServiceProvider();

var taskService = serviceProvider.GetService<TaskService>();
taskService.Execute();
