using System.Collections.Generic;

namespace TodoListApplication.Models
{
    public class Category : NamedEntity
    {
        public List<Todo> Todos { get; set; }
    }
}
