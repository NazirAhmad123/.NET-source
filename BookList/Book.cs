using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BookList
{
    class Book
    {
        ArrayList bokList = new ArrayList();

        // All methods
        public void Addb(string item)
        {
            bokList.Add(item);
        }
        public void ShowList()
        {
            
            Console.Write("You have (" + bokList.Count + ") book(s)\n");
           
            foreach(var i in bokList){
                Console.WriteLine(i);
            }
        }
        public void RemoveList(string item)
        {
            bokList.Remove(item);
        }
        public void modify(int position,string newItem)
        {
            //bokList.Insert(position, newItem);
            Console.WriteLine("Book " +(position+1)+" has been modified.");
        }
        public void Sort()
        {
            //var list = bokList.Cast<int>().ToList();

            bokList.Sort();
        }
    }
    
}
