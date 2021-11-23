using System;
using System.Collections.Generic;
using System.Linq;
using WorkingWithLists.Models;

namespace WorkingWithLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var todo1 = new Todo();
            todo1.Name = "Clean room";
            todo1.Description = "Just clean the room";
            todo1.Completed = false;

            var todo2 = new Todo()
            {
                Name = "Wash clothes",
                Description = "Just just the washing machine",
                Completed = true
            };

            var todo3 = new Todo()
            {
                Name = "Wash clothes",
                Description = "Just just the washing machine",
                Completed = true
            };

            var todos = new List<Todo>();
            todos.Add(todo1);
            todos.Add(todo2);
            todos.Add(todo3);

            // forEach -> forEach
            todos.ForEach(todo => todo.Description = "");
            // filter -> Where
            todos = todos.Where(t => t.Completed == true).ToList();
            // Map -> Select
            var names = todos.Select(t => t.Name + t.Description).ToList();
        }
    }
}
