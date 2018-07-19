using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class DictionaryCollection
    {
        static void Main()
        {
            List<Student> StudentsList = new List<Student>
            {
                 new Student{Name = "Nazir", Gender = "Male", Age = 24},
                 new Student{Name = "Bashir", Gender = "Male", Age = 25},
                 new Student{Name = "Hadia", Gender = "FeMale", Age = 12}
            };
            foreach (Student list in StudentsList)
            {
                Console.WriteLine(list.Name + " " + list.Gender + " " + list.Age);
            }

            Console.ReadKey();
        }
    }
}





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class Student
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }
    
}
