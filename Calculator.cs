using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    //class Calculator
    //{
    //    public void Add<T>(T a , T b)
    //    {
    //        dynamic d1 = a;
    //        dynamic d2 = b;
    //        Console.WriteLine(d1 + d2);
    //    }
    //    public void Sub<T>(T a, T b)
    //    {
    //        dynamic d1 = a;
    //        dynamic d2 = b;
    //        Console.WriteLine(d1 - d2);
    //    }
    //    public void Mult<T>(T a, T b)
    //    {
    //        dynamic d1 = a;
    //        dynamic d2 = b;
    //        Console.WriteLine(d1 * d2);
    //    }
    //    public void Div<T>(T a, T b)
    //    {
    //        dynamic d1 = a;
    //        dynamic d2 = b;
    //        Console.WriteLine(d1 / d2);
    //    }
    class Calculator<T>
    {
        public void Add(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine(d1 + d2);
        }
        public void Sub(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine(d1 - d2);
        }
        public void Mult(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine(d1 * d2);
        }
        public void Div(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine(d1 / d2);
        }
    }

        static void Main()
        {
            //Calculator calculator = new Calculator();
            //calculator.Add<int>(10, 5);
            //calculator.Sub<int>(20, 15);
            //calculator.Mult<int>(5, 3);
            //calculator.Div<int>(25, 5);

            Calculator<int> calculator = new Calculator<int>();
            calculator.Add(10, 5);
            calculator.Sub(20, 15);
            calculator.Mult(5, 3);
            calculator.Div(25, 5);


            Console.ReadKey();
        }
    }
}
