// See https://aka.ms/new-console-template for more information

using ShopApplication;

var shopConsole = new ShopConsole();

while (true)
{
    Console.WriteLine("Please enter the command: 'Add','List','Update'");

    var command = Console.ReadLine();

    if (command.StartsWith("Buy"))
    {
        shopConsole.ExecuteBuy();
    }
    else if (command.StartsWith("Show"))
    {
        shopConsole.ExecuteShowBalance();
    }
    else if (command.StartsWith("List"))
    {
        shopConsole.ExecutePrintInfo();
    }
}

