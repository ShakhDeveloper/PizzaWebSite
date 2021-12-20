using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebSite.ViewModels
{
    public class PizzaCreateViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Ingridients { get; set; }

        [Required]
        public IFormFile ImageFile { get; set; }
    }
}
