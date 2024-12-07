using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DesignPatterns.Models
{
    public class Person
    {
        public int Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Sex { get; set; } = default!;
        public int Age { get; set; } = default!;

        public void Update(Person person)
        {
            Name = person.Name;
            Sex = person.Sex;
            Age = person.Age;
        }
    }
}
