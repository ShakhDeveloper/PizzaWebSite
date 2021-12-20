using Microsoft.EntityFrameworkCore;
using PizzaWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebSite.PizzaDbEf
{
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options)
            : base(options)
        {

        }
        public DbSet <PizzaModel> pizzas { get; set; }
    }
}
