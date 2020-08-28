using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using northwind_app.Library.Models;
using northwind_app.ViewModels.Overview;

// Needed to use the session store.
using Microsoft.AspNetCore.Http;
// Needed to use Json.
using System.Text.Json;

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
            return View(new CustomersViewModel
            {
                Customers = customerService
                    .AllCustomers()
                    .Select(c => new CustomerViewModel
                    {
                        Name = c.ContactName,
                        City = c.City,
                        Id = c.CustomerId
                    }).ToList(),
                PreviousQueries = GetPreviousQueries(),
                TitleName = "Name",
                TitleCity = "City",
                TitleLink = "Orders",
                TitlePage = "Customers",
            });
        }

        [Route("Customers/{customerId}/Orders")]
        public IActionResult GetOrdersByCustomerId(string customerId)
        {
            return View(new OrdersViewModel
            {
                Orders = orderService
                    .GetOrdersByCustomerId(customerId)
                    .OrderBy(o => o.OrderDate)
                    .Select(o => new OrderViewModel
                    {
                        OrderDate = o.OrderDate,
                        Address = o.ShipAddress,
                        CustomerId = customerId,
                    }).ToList(),
                TitlePage = "Orders",
                TitleOrderDate = "Date",
                TitleAddress = "Address",
                CustomerId = customerId,
            });
        }

        [Route("[action]/{customerId}")]
        public IActionResult CreateOrder(string customerId)
        {
            return View(new OrderViewModel
            {
                CustomerId = customerId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public IActionResult SaveOrder(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                orderService.Add(order.OrderDate, order.Address, order.CustomerId);

                return RedirectToAction("GetOrdersByCustomerId",
                    "Overview",
                    new { CustomerId = order.CustomerId });
            }

            ModelState.AddModelError("", "Please fill in all required fields.");
            return View("CreateOrder", order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public IActionResult SearchCustomers(CustomersViewModel customersViewModel)
        {
            if (string.IsNullOrWhiteSpace(customersViewModel.SearchValue))
            {
                // No search value = return all customers.
                // WARNING: in real life one should prevent mass clicking the search button.
                return RedirectToAction("Index", "Overview");
            }
            else
            {
                var previousQueries = StoreSearchQuery(customersViewModel.SearchValue);
                return View("Index", new CustomersViewModel
                {
                    Customers = customerService
                        .AllCustomers()
                        .Where(c => c.ContactName.Contains(customersViewModel.SearchValue))
                        .Select(c => new CustomerViewModel
                        {
                            Name = c.ContactName,
                            City = c.City,
                            Id = c.CustomerId
                        }).ToList(),
                    TitlePage = "Customers",
                    TitleName = "Name",
                    TitleCity = "City",
                    TitleLink = "Orders",
                    PreviousQueries = GetPreviousQueries(),
                });
            }
        }

        [Route("[action]")]
        public IActionResult ClearSearch()
        {
            ClearPreviousQueries();
            return RedirectToAction("Index", "Overview");
        }

        private List<string> StoreSearchQuery(string query)
        {
            // Add the search string to the session state to remember it.
            List<string> previousQueries = GetPreviousQueries();

            if (!previousQueries.Contains(query))
            {
                previousQueries.Add(query);
            }

            // Overwrite the current searchQueries with the new results.
            HttpContext.Session.SetString("searchQueries", JsonSerializer.Serialize(previousQueries));

            return previousQueries;
        }

        private List<String> GetPreviousQueries()
        {
            // Get the raw json from the session store.
            string previousQueriesJson = HttpContext.Session.GetString("searchQueries");
            List<string> previousQueries = new List<string>();

            if (!string.IsNullOrEmpty(previousQueriesJson))
            {
                // When the searchQueries key is available deserialize into a list of strings.
                previousQueries = JsonSerializer.Deserialize<List<string>>(previousQueriesJson);
            }

            return previousQueries;
        }

        private void ClearPreviousQueries()
        {
            HttpContext.Session.SetString("searchQueries", JsonSerializer.Serialize(new List<string>()));
        }
    }
}