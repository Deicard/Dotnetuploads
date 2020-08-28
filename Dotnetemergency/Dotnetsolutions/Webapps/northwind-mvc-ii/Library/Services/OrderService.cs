using System;
using System.Linq;
using System.Collections.Generic;
using northwind_app.Library.Models;

namespace Library.Services
{
    public class OrderService
    {
        NorthwindContext context = new NorthwindContext();

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

        public IEnumerable<Orders> GetOrdersByCustomerId(string customerId) {
            return context.Orders.Where(o => o.CustomerId == customerId);
        }

        public Orders Add(DateTime? orderDate, string shipAddress, string customerId) {
            Orders order = new Orders();
            order.OrderDate = orderDate;
            order.ShipAddress = shipAddress;
            order.CustomerId = customerId;

            context.Add(order);
            context.SaveChanges();

            return order;
        }
    }
}