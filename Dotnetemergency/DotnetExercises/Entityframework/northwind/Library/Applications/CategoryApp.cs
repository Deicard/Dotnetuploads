using System;
using System.Linq;
using Library.Core;
using Library.Services;

namespace Library.Applications
{
    public class CategoryApp
    {
        private CategoryService service = new CategoryService();

        public void ShowList(){
            Console.WriteLine("Comming soon! :)");
            return;
        }

        public void Show(){
            Console.WriteLine("Comming soon! :)");
            return;
            
        }

        public void Add(){
            Console.WriteLine("Comming soon! :)");
            return;

        }

        public void Update(){
            Console.WriteLine("Comming soon! :)");
            return;

        }

        public void Delete(){
            Console.WriteLine("Comming soon! :)");
            return;
        }

        public static void ShowCommandList(){
            Console.WriteLine("category:list         show all categories");
            Console.WriteLine("category:add          add a new category");
            Console.WriteLine("category:show         show a new category");
            Console.WriteLine("category:update       update a category");
            Console.WriteLine("category:delete       delete acategory");
        }
    }
}