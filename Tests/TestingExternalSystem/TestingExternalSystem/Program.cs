// See https://aka.ms/new-console-template for more information
using TestingExternalSystem.Clients;
using TestingExternalSystem.Services;

Console.WriteLine("Hello, World!");

//Get data from https://jsonplaceholder.typicode.com/todos
// and calculate words which have length of 2 (and ofc test it)

var externalSystemClient = new ExternalSystemClient();

DataService dataService = new DataService(externalSystemClient);
await dataService.CalculateShortWordsFromApi();