using System.Collections.Generic;

namespace MobileStore.Models
{
    public class Company
    {
        public Company()
        {
            Phones = new List<Phone>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Phone> Phones { get; set; }
    }
}