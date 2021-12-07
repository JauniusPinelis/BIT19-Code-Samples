using System.ComponentModel;

namespace FirstMvcApplication.Models
{
    public class PersonModel
    {
        [DisplayName("President Full Name")]
        public string Name { get; set; }
    }
}
