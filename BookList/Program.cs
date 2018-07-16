using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Common;
using System.Configuration;

namespace BookList
{
    class Program
    {

        static Book BList = new Book();
        static void Main(string[] args)
        {
            bool quit = false;
            String input = "";
            DisplayMenu();
            while (!quit)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out int selectedOption))
                {
                    switch (selectedOption)
                    {
                        case 1:
                            DisplayMenu();
                            break;
                        case 2:
                            AddBook();
                            break;
                        case 3:
                            ShowList();
                            break;
                        case 4:
                            RemoveBook();
                            break;
                        case 5:
                            ModifyBook();
                            break;
                        case 6:
                            FindBook();
                            break;
                        case 7:
                            Quit();
                            quit = true;
                            break;
                    }
                }
            }
           // Console.ReadLine();
        }
        static void DisplayMenu()
        {
            Console.WriteLine("Press: ");
            Console.WriteLine("\t1. To display the menu.");
            Console.WriteLine("\t2. To show list.");
            Console.WriteLine("\t3. To add a book.");
            Console.WriteLine("\t4. To remove a book.");
            Console.WriteLine("\t5. To modify a book.");
            //Console.WriteLine("\t6. To find a book.");
            Console.WriteLine("\t7. To quit.");
        }
        static void AddBook()
        {
            Console.WriteLine("ADD");
            Console.Write("Enter the book name: ");
            //BList.Addb(Console.ReadLine());
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=NAZIR\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=True;Pooling=False");
SqlCommand cmd = new SqlCommand();
SqlDataReader reader;

cmd.CommandText = "SELECT * FROM Products";
cmd.CommandType = CommandType.Text;
cmd.Connection = sqlConnection1;

sqlConnection1.Open();

reader = cmd.ExecuteReader();
// Data is accessible through the DataReader object here.

sqlConnection1.Close();
        }
        static void ShowList()
        {
            BList.ShowList();
        }
        static void RemoveBook()
        {
            Console.WriteLine("REMOVE");
            Console.Write("\nEnter the book name: ");
            string bname = Console.ReadLine();
            BList.RemoveList(bname);
        }
        static void ModifyBook()
        {
            Console.WriteLine("MODIFY");
            Console.WriteLine("Enter item number: ");
            string itemNum = "";
            itemNum = Console.ReadLine();
            if (int.TryParse(itemNum, out int selectedOption))
            Console.WriteLine("Enter replacement item: ");
            string repl = Console.ReadLine();

            BList.modify((selectedOption - 1), repl);
        }
        static void FindBook()
        {
            Console.WriteLine("SEARCH");
            BList.Sort();
        }
        static void Quit()
        {
            Console.WriteLine("QUIT");
        }

        static void db(){}


    }
}
