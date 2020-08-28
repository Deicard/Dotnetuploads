using System;
using System.Collections.Generic;
using northwind_app.Library.Models;

namespace northwind_app.ViewModels.Overview
{
    public class CustomersViewModel {
        public string TitlePage {get; set;}
        public string TitleName {get; set;}
        public string TitleCity {get; set;}
        public string TitleLink {get; set;}
        public List<CustomerViewModel> Customers {get; set;}
        public string SearchValue {get; set;}
        public List<string> PreviousQueries {get; set;}
    }
}