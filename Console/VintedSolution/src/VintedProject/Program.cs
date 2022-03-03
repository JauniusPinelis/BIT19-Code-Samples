// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using VintedProject;

var services = new ServiceCollection();

services.AddTransient<Executor>();

var serviceProvider = services.BuildServiceProvider();

var executor = serviceProvider.GetRequiredService<Executor>();
executor.Execute();
