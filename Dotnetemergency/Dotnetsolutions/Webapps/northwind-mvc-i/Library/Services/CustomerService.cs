using System;
using System.Linq;
using System.Collections.Generic;
using northwind_app.Library.Models;

namespace Library.Services
{
    public class CustomerService
    {
        northwindDBContext context = new northwindDBContext();

        public Customers GetCustomer(string id){
            var results = context.Customers.Where(c => c.CustomerId == id);
            if(results.Count() == 0){
                return null;
            }
            
            return context.Customers.Where(c => c.CustomerId == id).First();
            
        }

        public Customers Add(string name, string city){
            Customers Customer = new Customers();

            Customer.City = city;
            Customer.CompanyName = name;

            
            context.Add(Customer);
            context.SaveChanges();

            return Customer;
        }

        public Customers Update(string id, string name, string city){
            Customers Customer = GetCustomer(id);
            if(Customer == null){
                return null;
            }

            Customer.ContactName = name;
            Customer.City = city;
            context.SaveChanges();

            return Customer;
            
        }

        public void Delete(Customers Customer){
            context.Remove(Customer);
            context.SaveChanges();
        }

        public IEnumerable<Customers> AllCustomers(){
            return context.Customers.OrderBy(c => c.ContactName);
        }
    }
}