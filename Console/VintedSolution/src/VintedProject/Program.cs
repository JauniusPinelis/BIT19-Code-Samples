// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using VintedProject;
using VintedProject.Extensions;

var services = new ServiceCollection();

services.ConfigureServices();

var serviceProvider = services.BuildServiceProvider();

var executor = serviceProvider.GetRequiredService<Executor>();
await executor.ExecuteAsync();
