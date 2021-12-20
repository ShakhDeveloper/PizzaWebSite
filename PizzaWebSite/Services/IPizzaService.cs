using Microsoft.AspNetCore.Http;
using PizzaWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebSite.Services
{
    interface IPizzaService
    {
        List<PizzaModel> GetAllPizzas();
        PizzaModel GetById(Guid id);
        PizzaModel AddPizzaz(PizzaModel newpizza);
        PizzaModel Update(PizzaModel pizza);
        PizzaModel Delete(Guid id);
        string SaveImage(IFormFile newFile);
        object SaveImage(object imageFile);
        PizzaModel AddPost(PizzaModel newpizza);
    }
}
