using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PizzaWebSite.Models;
using PizzaWebSite.PizzaDbEf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebSite.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly PizzaDbContext _dbContext;

        public PizzaService(IWebHostEnvironment webHostEnvironment, PizzaDbContext dbContext)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public PizzaModel AddPizzaz(PizzaModel newpizza)
        {
            newpizza.Id = Guid.NewGuid();
            _dbContext.Add(newpizza);
            _dbContext.SaveChanges();

            return newpizza;
        }

        public PizzaModel Delete(Guid id)
        {
            PizzaModel pizzas = _dbContext.pizzas.FirstOrDefault(p => p.Id == id);
            if (pizzas.Ingredients is not null)
            {
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                string filePath = Path.Combine(uploadFolder, pizzas.Ingredients);
                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
                
            }

            _dbContext.pizzas.Remove(pizzas);
            _dbContext.SaveChanges();
            return pizzas;
        }

        public List<PizzaModel> GetAllPizzas()
        {
            return _dbContext.pizzas.ToList();
        }

        public PizzaModel GetById(Guid id)
        {
            return _dbContext.pizzas.FirstOrDefault(pizza => pizza.Id == id);
        }

        public PizzaModel Update(PizzaModel pizza)
        {
            _dbContext.pizzas.Update(pizza);
            _dbContext.SaveChanges();

            return pizza;
        }

        public string SaveImage(IFormFile newFile)
        {
            string uniqueName = string.Empty;
            if (newFile.FileName != null)
            {
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueName = Guid.NewGuid().ToString() + "_" + newFile.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueName);
                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                newFile.CopyTo(fileStream);
                fileStream.Close();
            }

            return uniqueName;
        }
    }
}
