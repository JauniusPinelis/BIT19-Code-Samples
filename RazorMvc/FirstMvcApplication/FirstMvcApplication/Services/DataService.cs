using FirstMvcApplication.Models;
using System.Collections.Generic;

namespace FirstMvcApplication.Services
{
    public class DataService
    {
        private List<PersonModel> persons = new List<PersonModel>()
        {
            new PersonModel() { Name = "Gitanas Nauseda"},
            new PersonModel() { Name = "Dalia Grybauskaite"}
        };

        public List<PersonModel> GetAll()
        {
            return persons;
        }

        public void Add(PersonModel personModel)
        {
            persons.Add(personModel);
        }
    }
}
