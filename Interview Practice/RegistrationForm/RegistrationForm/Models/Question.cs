using RegistrationForm.Models.Bases;

namespace RegistrationForm.Models
{
    public class Question : TitledEntity
    {

        public List<Answer> PossibleAnswers { get; set; }

        public int? AnswerId { get; set; }

        public int FormId { get; set; }
    }
}
