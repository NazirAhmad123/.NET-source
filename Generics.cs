using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class Generics1
    {
        //public bool Compare(int a, int b)
        //{
        //    if(a == b)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //public bool Compare(object a, object b)
        //{
        //    if (a.Equals(b))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        public bool Compare<T>(T a, T b)
        {
            if (a.Equals(b))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main()
        {
            Generics1 generics1 = new Generics1();
            //bool result = generics1.Compare(10, 20);
            //bool result = generics1.Compare(true, true);
            //bool result = generics1.Compare<float>(1.2f, 1.2f);
            bool result = generics1.Compare<int>(10, 20);
            Console.WriteLine(result);
            Console.ReadKey();

        }
    }
}
