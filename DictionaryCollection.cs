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
            Dictionary<string, object> dt = new Dictionary<string, object>();
            dt.Add("Eid", 1010);
            dt.Add("Ename", "Nazir");
            dt.Add("Job", ".NET Develper");
            dt.Add("Phone", "0182728283");
            dt.Add("Email", "nazir@apdgroup.com");
            dt.Add("Location", "KL");

            foreach (string key in dt.Keys)
                Console.WriteLine(key + ": " + dt[key]);

            Console.ReadKey();
        }
    }
}
