using System;
using System.Linq;
using System.Collections.Generic;
using Library.Core;
using Library.Services;
using northwind_app.Library.Models;

namespace Library.Applications
{
    public class CategoryApp
    {
        private CategoryService service = new CategoryService();
        private ProductService productService = new ProductService();

        public void ShowList(){
            var list = service.AllCategories().Select( c => $"{c.CategoryId} {c.CategoryName}").ToList();
            ShowListView(list);
        }

        private void ShowListView(IEnumerable<string> list){
            Console.WriteLine($"-----------------------------------");
            Console.WriteLine($"List");
            Console.WriteLine($"-----------------------------------");
            foreach(string item in list){
                Console.WriteLine(item);
            }
            Console.WriteLine($"-----------------------------------");
        }

        public void Show(){
            int id = ConsoleReader.ReadNumber("Category id:");
            Categories category = service.GetCategory(id);
            ShowView(category, id);
            
        }

        public void ShowCategoryProducts(){
            int id = ConsoleReader.ReadNumber("Category id:");
            List<Products> products = productService.GetProductsByCategoryId(id);
            ShowListView(products.Select( p => $"{p.ProductName}, is discontinued: {p.Discontinued}"));
        }

        private void ShowView(Categories category, int? id = null){
            Console.WriteLine($"-----------------------------------");
            Console.WriteLine($"Show category");
            Console.WriteLine($"-----------------------------------");

            if( category == null){
                
                Console.WriteLine($"No category found with id {id}");
                Console.WriteLine($"-----------------------------------");
                return;
            }
        
            Console.WriteLine($"id:          {category.CategoryId}");
            Console.WriteLine($"name:        {category.CategoryName}");
            Console.WriteLine($"description: {category.Description}");
            Console.WriteLine($"-----------------------------------");
        }

        public void Add(){
            Console.WriteLine($"name:");
            string name = Console.ReadLine();
            Console.WriteLine($"description:");
            string description = Console.ReadLine();

            var category = service.Add(name, description);
            Console.WriteLine("Category successfully added.");
            ShowView(category);

        }

        public void Update(){
            int id = ConsoleReader.ReadNumber("Category id:");
            Categories category = service.GetCategory(id);
            ShowView(category, id);
            if(category == null){
                return;
            }

            Console.WriteLine($"name:");
            string name = Console.ReadLine();
            Console.WriteLine($"description:");
            string description = Console.ReadLine();
           

            category = service.Update(id, name, description);
            Console.WriteLine("Category successfully updated.");
            ShowView(category);

        }

        public void Delete(){
            int id = ConsoleReader.ReadNumber("Category id:");
            Categories category = service.GetCategory(id);
            ShowView(category, id);
            if(category == null){
                return;
            }

            int counter = 0;
            string answer = "";
            do{
                Console.WriteLine($"Are you sure you want to delete ${category.CategoryName}? (y/n)");
                answer = Console.ReadLine();
                counter++;
                if(counter > 3){
                    Console.WriteLine("Please try again when you make up your mind.");
                    return;
                }
            }while(!(answer == "y" || answer == "n"));

            if(answer == "y"){
                string name = category.CategoryName;
                service.Delete(category);
                Console.WriteLine($"Category {name} successfully deleted!");
            }
        }

        public static void ShowCommandList(){
            Console.WriteLine("category:list         show all categories");
            Console.WriteLine("category:add          add a new category");
            Console.WriteLine("category:show         show a new category");
            Console.WriteLine("category:showProducts show products belonging to a category");
            Console.WriteLine("category:update       update a category");
            Console.WriteLine("category:delete       delete acategory");
        }
    }
}