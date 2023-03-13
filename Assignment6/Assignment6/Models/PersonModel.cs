using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6.Models
{
    public class PersonModel
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public PersonModel(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
