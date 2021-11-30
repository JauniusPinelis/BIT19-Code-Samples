// See https://aka.ms/new-console-template for more information
using BookStoreApplication;

var bookStoreConsole = new BookStoreConsole();

while (true)
{
    Console.WriteLine("Please enter the command: 'Add' or 'List'");

    var command = Console.ReadLine();

    switch (command)
    {
        case "Add":
            bookStoreConsole.ExecuteAdd();
            break;
        case "List":
            bookStoreConsole.ExecuteList();
            break;
        case "Remove":
            bookStoreConsole.ExecuteRemove();
            break;

        default:
            Console.WriteLine("Command was not recognised, please try again");
            break;
    }
}

