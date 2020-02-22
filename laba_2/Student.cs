using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_2
{
    class Student : IPerson
    {
        public string Name { get; }
        public string Patronomic{get; } 
        public string LastName { get; }
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime BirthDate { get; }
        public int Course { get; }
        public string Group { get; }
        public double AverageMark { get; }
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
        public Student() { }
        public Student(string name,
                       string patronomic,
                       string lastname,
                       DateTime birthdate,
                       int course,
                       string group,
                       double avgMark)
        {
            this.Name = name;
            this.Patronomic = patronomic;
            this.LastName = lastname;
            this.BirthDate = birthdate;
            this.Course = course;
            this.Group = group;
            this.AverageMark = avgMark;
        }

        public static Student Parse(string objectInJson)
        {
            return JsonConvert.DeserializeObject<Student>(objectInJson);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this,new JavaScriptDateTimeConverter());
        }
    }
}
