using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class HashCollection
    {
        static void Main()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("Eid", 1010);
            hashtable.Add("Ename", "Nazir");
            hashtable.Add("Job", ".NET Develper");
            hashtable.Add("Phone", "0182728283");
            hashtable.Add("Email", "nazir@apdgroup.com");
            hashtable.Add("Location", "KL");

            //Console.WriteLine(hashtable["Ename"]);

            foreach (object keys in hashtable.Keys)
                Console.WriteLine(keys + ":" + hashtable[keys]);

            //foreach(object values in hashtable.Values)
            //Console.WriteLine(values);

            Console.ReadKey();
        }
    }
}
