// See https://aka.ms/new-console-template for more information
using BookStoreApplication;

var bookStoreConsole = new BookStoreConsole();

while (true)
{
    Console.WriteLine("Please enter the command: 'Add','List','Update'");

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
        case "Update":
            bookStoreConsole.ExecuteUpdate();
            break;

        default:
            Console.WriteLine("Command was not recognised, please try again");
            break;
    }
}

