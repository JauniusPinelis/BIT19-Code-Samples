namespace TodoListApplication.Models
{
    public class Todo : NamedEntity
    {
        public string Description { get; set; }

        public Category Category { get; set; }
    }
}
