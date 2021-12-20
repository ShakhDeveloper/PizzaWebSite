using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebSite.Models
{
    public class PizzaModel
    {
        public Guid  Id { get; set; }
        public string Title { get; set; }
        public string ShortName { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }
        public string ImageFileName { get; internal set; }
    }
}
