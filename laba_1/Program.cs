using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person
{
    class Program
    {
        static void Main(string[] args)
        {
            var textPersons = File.ReadAllLines(@"input.txt");
            var parsedPersons = ParsePersons(textPersons);
            var orderedPersons = parsedPersons.OrderBy(x => x.BirthDate).ToArray();
            File.WriteAllLines(@"output.txt", СonvertToString(orderedPersons));
            Console.ReadKey();
        }

        public static Person[] ParsePersons(string [] file)
        {
            List<Person> result =new List<Person>();
            foreach(string line in file)
            {
                result.Add(Person.Parse(line));
            }
            return result.ToArray();
        }
        
        public static IEnumerable<string> СonvertToString(Person[] persons)
        {
            List<string> result = new List<string>();
            foreach(Person person in persons)
            {
                result.Add(person.ToString());
            }
            return result;
        }
    }
}
