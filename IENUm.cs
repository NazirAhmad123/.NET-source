using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionLast
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>
            {
                1,2,3,4,5,6,7,8,9,10
            };

            foreach (int i in nums)
                Console.Write(i + " ");

            Console.WriteLine();
            IEnumerable<int> ienum = (IEnumerable<int>)nums;

            foreach (int i in ienum)
                Console.Write(i + " ");


            IEnumerator<int> enumerator = nums.GetEnumerator();
            Console.WriteLine();
            while (enumerator.MoveNext())
            {
                Console.Write(enumerator.Current.ToString() + " ");
            }

            Console.ReadKey();
        }
    }
}
