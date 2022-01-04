using RegistrationForm.Models.Bases;
using System.ComponentModel.DataAnnotations;

namespace RegistrationForm.Models
{
    public class Answer : TitledEntity
    {
        [Required]
        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
