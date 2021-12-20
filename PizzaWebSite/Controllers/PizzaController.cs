using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaWebSite.Models;
using PizzaWebSite.Services;
using PizzaWebSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebSite.Controllers
{
    public class PizzaController : Controller
    {
        private IPizzaService _pizzaService;
        private IPizzaService pizzaService;

        public string Title { get; private set; }
        public string Ingredients { get; private set; }
        public IFormFile ImageFileName { get; private set; }

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }
        public IActionResult Index()
        {
            List<PizzaModel> list = _pizzaService.GetAllPizzas();
            return View("Index", list);
        }

        public IActionResult AddPost()
        {
            return View();
        }

        public IActionResult AddPost(PizzaController viewModel)
        {
            PizzaModel newpizza = null;
            if (ModelState.IsValid)
            {
                newpizza = new PizzaModel()
                {
                    Title = viewModel.Title,
                    Ingredients = viewModel.Ingredients,
                    ImageFile = _pizzaService.SaveImage(viewModel.ImageFileName)
                };
                newpizza = _pizzaService.AddPost(newpizza);
            }

            return RedirectToAction("ViewPost", newpizza);
        }

        [HttpGet]
        public IActionResult EditPost(Guid id)
        {
            PizzaModel post = _pizzaService.GetById(id);
            PizzaEditViewModel viewModel = new PizzaEditViewModel()
            {
                Id = post.Id,
                Title = post.Title,
                Ingridients = post.Ingredients,
                ImageFile = post.ImageFileName
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditPost(PizzaEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                IFormFile imageFile = viewModel.ImageFile;
                string imageSource = ImageFileName;
                if (viewModel.ImageFile != null)
                {
                    imageSource = _pizzaService.SaveImage(viewModel.ImageFile);
                }

                PizzaModel post = new PizzaModel()
                {
                    Id = viewModel.Id,
                    Title = viewModel.Title,
                    Ingredients = viewModel.Ingridients,
                    ImageFile = ImageFileName
                };

                post = _pizzaService.Update(post);

                return RedirectToAction("ViewPost", post);
            }
            return View();
        }
    }
}
