using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_2
{
    class Teacher : IPerson
    {
        public enum Position { Junior, Middle, Senior };
        public Position TeacherPosition { get; }
        public string Name { get;}
        public string Patronomic { get; }
        public string LastName { get; }
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
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
        public string Department { get; }
        public int Experience { get; }
        public Teacher() { }
        public Teacher(string name,
                       string patronomic,
                       string lastname,
                       DateTime birthdate,
                       Position teacherposition,
                       string department,
                       int experience)
        {
            this.Name = name;
            this.Patronomic = patronomic;
            this.LastName = lastname;
            this.BirthDate = birthdate;
            this.TeacherPosition = teacherposition;
            this.Department = department;
            this.Experience = experience;
        }
        public static Teacher Parse(string objectInJson)
        {
            return JsonConvert.DeserializeObject<Teacher>(objectInJson);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JavaScriptDateTimeConverter());
        }

    }
}
