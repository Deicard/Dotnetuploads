using System;
using System.Collections.Generic;
using northwind_app.Library.Models;

namespace northwind_app.ViewModels.Overview
{
    public class OrdersViewModel {
        public string TitlePage {get; set;}
        public string TitleOrderDate {get; set;}
        public string TitleAddress {get; set;}
        public string CustomerId {get; set;}
        public List<OrderViewModel> Orders {get; set;}
    }
}