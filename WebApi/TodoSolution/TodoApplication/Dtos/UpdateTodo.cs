using System.ComponentModel.DataAnnotations;

namespace TodoApplication.Dtos
{
    public class UpdateTodo
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }
    }
}
