using RegistrationForm.Models.Bases;

namespace RegistrationForm.Models
{
    public class Form : Entity
    {
        public List<Question> Questions { get; set; }
    }
}
