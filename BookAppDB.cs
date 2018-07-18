using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Enter a book name: ");


            using (var db = new BookAppDBEntities())
            {
                var b1 = new BookTable()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cplusplus"
                };
                var b2 = new BookTable()
                {
                    Id = Guid.NewGuid(),
                    Name = "C Objective"
                };
                var b3 = new BookTable()
                {
                    Id = Guid.NewGuid(),
                    Name = "F sharp"
                };

                Guid id = Guid.Parse("00000000-0000-0000-0000-000000000000");

                //var bk = db.BookTables.Where(x => x.Id == id).FirstOrDefault();
                //bk.Name = "C sharp";

                db.BookTables.Add(b1);
                db.BookTables.Add(b2);
                db.BookTables.Add(b3);
                db.SaveChanges();
            }
        }
        static void Menu()
        {
            Console.WriteLine("Press:");
            Console.WriteLine("\t1. Add");
            Console.WriteLine("\t2. Remove");
            Console.WriteLine("\t3. Update");
        }
    }
}
