using System.ComponentModel;

namespace ReflectionDemo.Model
{
    public class Todo
    {
        [DisplayName]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; } = "Unknown";

        public string Location { get; set; }

        public decimal Test { get; set; }
    }
}
