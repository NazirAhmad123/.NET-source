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

            Menu();

            bool quit = false;
            string input = "";

            while (!quit)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out int selectedOption))
                {
                    switch (selectedOption)
                    {
                        case 1:
                            Add();
                            break;
                        case 2:
                            Remove();
                            break;
                        case 3:
                            Update();
                            break;
                        case 4:
                            Display();
                            break;
                        case 5:
                            Find();
                            break;
                    }
                }
            }
            Console.ReadKey();
        }
        static void Menu()
        {
            Console.WriteLine("Press:");
            Console.WriteLine("\t1. Add");
            Console.WriteLine("\t2. Remove");
            Console.WriteLine("\t3. Update");
            Console.WriteLine("\t4. Display List");
            Console.WriteLine("\t5. Find");

        }
        static void Add()
        {
            //Console.WriteLine("Nothing");
            Console.WriteLine("Enter a book name: ");
            string input = Console.ReadLine();
            using(var db = new BookAppDBEntities())
            {
                var book = new BookTable()
                {
                    // var input = Console.ReadLine();
                    Id = Guid.NewGuid(),
                    Name = input
            };
                db.BookTables.Add(book);
                db.SaveChanges();
                Console.WriteLine($"{input} was being added.");
            }

        }
        static void Remove()
        {
            //Console.WriteLine("Nothing");
            Console.WriteLine("What book do you want to remove: ");
            string input = Console.ReadLine();
            using (var db = new BookAppDBEntities())
            {
                //var book = new BookTable()
                //{
                //    Id = Guid.NewGuid(),
                //    Name = Console.ReadLine()

                //};
                //db.BookTables.Remove(book);
                //db.SaveChanges();
                var book = db.BookTables
                            .Where(x => x.Name == input).FirstOrDefault();

                db.BookTables.Remove(book);
                db.SaveChanges();
                Console.WriteLine($"{input} was being removed.");
            }
        }
        static void Update()
        {
            //Console.WriteLine("Nothing");
            Console.WriteLine("What book do you want to update: ");
            string oldName = Console.ReadLine();

            using (var db = new BookAppDBEntities())
            {
                var book = db.BookTables
                    .Where(x => x.Name == oldName).FirstOrDefault();
                db.BookTables.Remove(book);
                db.SaveChanges();
                Console.WriteLine("Enter the new name: ");
                string newName = Console.ReadLine();
                if (book != null)
                {
                   
                        var newBook = new BookTable()
                        {
                            // var input = Console.ReadLine();
                            Id = Guid.NewGuid(),
                            Name = newName

                        };

                    db.BookTables.Add(newBook);
                    db.SaveChanges();
                    Console.WriteLine($"{newName} was being updated.");
                }
              //  Console.WriteLine($"{newName} was being updated.");
            }
        }
        static void Display()
        {
            //Console.WriteLine("Nothing");
            using(var db = new BookAppDBEntities())
            { 
                foreach (var books in db.BookTables)
                {
                    Console.WriteLine(books.Name);
                }
;            }
        }
        static void Find()
        {
            Console.WriteLine("Enter the name of the book to find in DB: ");
            string input = Console.ReadLine();
            using(var db = new BookAppDBEntities())
            {
                var newBook = new BookTable()
                {
                    // var input = Console.ReadLine();
                    Id = Guid.NewGuid(),
                    Name = input

                };
                // var b = db.BookTables.Where(x => x.Name == input).FirstOrDefault();
                //var b = db.BookTables
                //            .Select(x => x.Name == input).FirstOrDefault();


                //Console.WriteLine($"{b}");
                //  db.SaveChanges();
                var book = db.BookTables.SingleOrDefault(p => p.Name == input);
                //Console.WriteLine("{0} was found.", book.Name);
                Console.WriteLine("{0} was found.");
            }
        }
    }
}
