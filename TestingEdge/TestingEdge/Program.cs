using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingEdge
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public class Startup
    {

        public async Task<object> Invoke(dynamic input)
        {
            string name = (string)input.name;
            int age = (int)input.age;
            Person person = new Person(name, age);
            return person;
        }
    }
}
