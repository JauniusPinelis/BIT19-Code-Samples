using System.Collections.Generic;
using TodoListApplication.Models;

namespace TodoListApplication.Dtos
{
    public class CreateTodo
    {
        public Todo Todo { get; set; } //Not a good practice

        public List<Category> AllCategories { get; set; }

        public List<int> SelectedTagIds { get; set; } // will contains info on selected tags

        public List<Tag> Tags { get; set; } //Tags to display
    }
}
