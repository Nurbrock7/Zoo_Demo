using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using System;
using System.Threading.Tasks;
using WebApplication1.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Zoo_App.Models;

namespace WebApplication1.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ZooDbContext _MVCzooDbContext;

        public AnimalController(ZooDbContext MVCzooDbContext)
        {
            _MVCzooDbContext = MVCzooDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
          var animal = await _MVCzooDbContext.Animal.ToListAsync();
            return View(animal);
            
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAnimalViewModel addAnimalRequest)
        {
             var animal = new ZooModel()
            {
                id = Guid.NewGuid(),
                Name = addAnimalRequest.Name,
                Species = addAnimalRequest.Species,
                Colour = addAnimalRequest.Colour,
                DateOfBirth = addAnimalRequest.DateOfBirth,
            };

            await _MVCzooDbContext.AddAsync(animal);
            await _MVCzooDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]

        public async Task<IActionResult> View(Guid Id)
        {
            var animal = await _MVCzooDbContext.Animal.FirstOrDefaultAsync(x => x.Id == Id);

            if (animal != null)
            {
                var viewModel = new UpdateAnimalViewModel()
                {
                    id = animal.Id,
                    Name = animal.Name, 
                    Species = animal.Species,
                    Colour = animal.Colour,
                    DateOfBirth = animal.DateOfBirth,
                };
            return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");  
        }

        [HttpPost]

        public async Task<IActionResult> View(UpdateAnimalViewModel model)
        {
            var animal = await _MVCzooDbContext.Animal.FindAsync(model.id);

            if (animal != null)
            {
                animal.Name = model.Name;
                animal.Species = model.Species; 
                animal.Colour = model.Colour;  
                animal.DateOfBirth = model.DateOfBirth;

                await _MVCzooDbContext.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(UpdateAnimalViewModel model)
        {
            var animal = await _MVCzooDbContext.Animal.FindAsync(model.id); 
            if (animal != null)
            {
                _MVCzooDbContext.Animal.Remove(animal);
                await _MVCzooDbContext.SaveChangesAsync();  

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }

    
}
