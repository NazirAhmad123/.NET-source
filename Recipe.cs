using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesApp
{
    class Program
    {
        static void Main(string[] args)
        {

            using (RecipeEntities db = new RecipeEntities())
            {
                Recipe recipe = new Recipe()
                {
                    Name = "Chicken"
                };

                db.Recipes.Add(recipe);
                db.SaveChanges();


                //Recipe r = db.Recipes.FirstOrDefault(x => x.Name == "Burger");
                //Console.WriteLine(r.Id);

                //Console.WriteLine("Done");
                //r.Name = "Burger";
                //db.SaveChanges();
                //db.Recipes.Remove(r);
                //db.SaveChanges();
                Console.WriteLine("Done");
                Console.ReadKey();
            }
        }
    }
}
