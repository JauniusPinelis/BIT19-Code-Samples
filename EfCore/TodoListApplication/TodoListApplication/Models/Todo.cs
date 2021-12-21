using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoListApplication.Models
{
    public class Todo : NamedEntity
    {
        [MinLength(2)]
        public string Description { get; set; }

        public Category Category { get; set; }

        public int? CategoryId { get; set; }

        public List<TodoTag> TodoTags { get; set; }
    }
}
