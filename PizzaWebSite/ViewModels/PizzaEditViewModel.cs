using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebSite.ViewModels
{
    public class PizzaEditViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Ingridients { get; set; }
        public string ImageFileName { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
