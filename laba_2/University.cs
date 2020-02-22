using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_2
{
    class University : IUniversity
    {

        public List<IPerson> _people = new List<IPerson>();

        public void Add(IPerson person)
        {
            if (person != null)
            _people.Add(person);
        }
        public void Remove(IPerson person)
        {
            _people.RemoveAll(x => arePersonsEqual(x, person));
        }

        public IEnumerable<IPerson> Persons
        {
            get => _people.OrderBy(x => x.LastName);
        }

        public IEnumerable<Student> Students
        {
            get => _people.OfType<Student>().OrderBy(x => x.LastName);
        }

        public IEnumerable<Teacher> Teachers
        {
            get => _people.OfType<Teacher>().OrderBy(x => x.LastName);
        }

        public IEnumerable<IPerson> FindByLastName(string lastName)
        {
            return _people.OrderBy(x => x.LastName).Where(x => x.LastName == lastName);
        }

        public IEnumerable<Teacher> FindByDepartment(string lastName)
        {
            return _people.OfType<Teacher>().OrderBy(x => x.TeacherPosition);
        }

        private bool arePersonsEqual(IPerson person1, IPerson person2)
        {
            if(person1.Age == person2.Age &&
                person1.BirthDate == person2.BirthDate &&
                 person1.LastName == person2.LastName &&
                  person1.Name == person2.Name &&
                   person1.Patronomic == person2.Patronomic)
                        return true;
            return false;
        }
    }
}
