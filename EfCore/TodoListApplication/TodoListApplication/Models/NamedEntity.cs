using System.ComponentModel.DataAnnotations;

namespace TodoListApplication.Models
{
    public abstract class NamedEntity : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
