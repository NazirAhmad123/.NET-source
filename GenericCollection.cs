using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class GenericList
    {
        static void Main()
        {
            List<int> list = new List<int>
            {
                50,
                10,
                5
            };

            foreach(int i in list)
            {
                Console.WriteLine(i + " ");
            }

            list.Insert(3, 100);
            foreach (int i in list)
            {
                Console.WriteLine(i + " ");
            }

            list.RemoveAt(1);
            for(int i=0; i<list.Count; i++)
            {
                Console.WriteLine(list[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
