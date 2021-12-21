using System.Collections.Generic;

namespace TodoListApplication.Models
{
    public class Tag : NamedEntity
    {
        public List<TodoTag> TodoTags { get; set; }
    }
}
