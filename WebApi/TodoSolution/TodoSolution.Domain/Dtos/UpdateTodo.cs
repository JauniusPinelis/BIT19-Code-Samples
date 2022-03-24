using System.ComponentModel.DataAnnotations;

namespace TodoSolution.Domain.Dtos
{
    public class UpdateTodo
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }
    }
}
