using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace LinqPractice
{
    class Program
    {
        static void Main(string[] args)
        {

            ArrayList MyList = new ArrayList();
            Console.WriteLine(MyList.Capacity);
            //MyList.add(10);
            MyList.Add(10);
            MyList.Add(20);
            MyList.Add(30);
            MyList.Add(40);


            MyList.Insert(2, 50);

            MyList.Remove(1);
            foreach (object i in MyList)
                Console.Write(i + " ");



            Console.ReadKey();
        }
    }
}
