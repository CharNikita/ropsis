using System;
using System.Globalization;

namespace person
{
    public class Person
    {
        public string Name { get; }
        public string Surname { get; }
        public string Patronymic { get; }
        public float Weight { get; }
        private readonly bool _ismale;
        public bool IsMale
        {
            get { return _ismale; }
        }
        public DateTime BirthDate { get; }
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;
                if(BirthDate > today.AddYears(-age)) age--;
                return age;
            }
        }
        public Person(string name, string surname, string patronymic, float weight, bool ismale, DateTime bithdate)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Weight = weight;
            _ismale = ismale;
            BirthDate = bithdate;
        }

        public override string ToString()
        {
            return $"{Name} {Surname} {Patronymic} "
                    + $"{Weight:#.####} {(IsMale ? "male" : "Female")}" +
                    $"{BirthDate: d MMM yyyy} {Age}"
                ;
        }
        public static Person Parse(string text)
        {
            var fields = text.Split(' ');
            return new Person(fields[0], fields[1], fields[2],
                float.Parse(fields[3]), fields[4] =="male"?true:false, 
                DateTime.ParseExact(fields[5], "d.MMM.yyyy", CultureInfo.InvariantCulture));
        }
    }
}