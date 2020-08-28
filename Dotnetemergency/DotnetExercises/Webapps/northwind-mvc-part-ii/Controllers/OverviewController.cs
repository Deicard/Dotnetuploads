using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using northwind_app.Library.Models;

namespace northwind_app.Controllers
{
    [Route("")]
    [Route("[controller]")]
    public class OverviewController : Controller
    {
        CustomerService customerService = new CustomerService();
        OrderService orderService = new OrderService();

        [Route("")]
        [Route("[action]")]
        public IActionResult Index()
        {
            return View(customerService.AllCustomers().ToList());
        }

        [Route("Customers/{customerId}/Orders")]
        public IActionResult GetOrdersByCustomerId(string customerId)
        {
            return View(orderService
                    .GetOrdersByCustomerId(customerId)
                    .OrderBy(o => o.OrderDate)
                    .ToList());
        }
    }
}