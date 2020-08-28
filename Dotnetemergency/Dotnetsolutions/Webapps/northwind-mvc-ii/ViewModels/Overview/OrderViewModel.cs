using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using northwind_app.Library.Models;

namespace northwind_app.ViewModels.Overview
{
    public class OrderViewModel {

        [Required]
        public DateTime? OrderDate {get; set;}

        [Required]
        [MinLength(3), MaxLength(50)]
        public string Address {get; set;}

        [Required]
        public string CustomerId {get; set;}
    }
}
