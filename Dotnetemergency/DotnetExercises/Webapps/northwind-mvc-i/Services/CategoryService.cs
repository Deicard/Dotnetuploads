using System;
using System.Linq;
using System.Collections.Generic;
using northwind_app.Library.Models;

namespace Services
{
    public class CategoryService
    {
        northwindDBContext context = new northwindDBContext();

        public Categories GetCategory(int id){
            var results = context.Categories.Where(c => c.CategoryId == id);
            if(results.Count() == 0){
                return null;
            }
            
            return context.Categories.Where(c => c.CategoryId == id).First();
            
        }

        public Categories Add(string name, string description){
            Categories category = new Categories();

            category.CategoryName = name;
            category.Description = description;

            
            context.Add(category);
            context.SaveChanges();

            return category;
        }

        public Categories Update(int id, string name, string description){
            Categories category = GetCategory(id);
            if(category == null){
                return null;
            }

            category.CategoryName = name;
            category.Description = description;
            context.SaveChanges();

            return category;
            
        }

        public void Delete(Categories category){
            context.Remove(category);
            context.SaveChanges();
        }

        public IEnumerable<Categories> AllCategories(){
            return context.Categories.OrderBy(c => c.CategoryName);
        }
    }
}