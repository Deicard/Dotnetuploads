using System;
using System.Linq;
using System.Collections.Generic;
using northwind_app.Library.Models;

namespace Library.Services
{
    public class OrderService
    {
        northwindDBContext context = new northwindDBContext();

        public Orders GetOrder(int id){
            var results = context.Orders.Where(c => c.OrderId == id);
            if(results.Count() == 0){
                return null;
            }
            
            return context.Orders.Where(c => c.OrderId == id).First();
            
        }

        public void Delete(Orders Order){
            context.Remove(Order);
            context.SaveChanges();
        }

        public IEnumerable<Orders> AllOrders(){
            return context.Orders.OrderBy(o => o.OrderId);
        }
    }
}