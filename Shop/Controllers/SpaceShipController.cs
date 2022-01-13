using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Dtos;
using Shop.Core.ServiceInterface;
using Shop.Data;
using Shop.Models.SpaceShip;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class SpaceShipController : Controller
    {
        private readonly ShopDbContext _context;
        private readonly ISpaceShipService _SpaceShipService;
        private readonly IFileServices _fileServices;

        public SpaceShipController
            (
            ShopDbContext context,
            ISpaceShipService SpaceShipService,
            IFileServices fileServices
            )
        {
            _context = context;
            _SpaceShipService = SpaceShipService;
            _fileServices = fileServices;
        }

        //ListItem
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.SpaceShips
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new SpaceListItem
                {
                    Id = x.Id,
                    Name = x.Name,
                    Model = x.Model,
                    Company = x.Company,
                    EnginePower = x.EnginePower,
                    Country = x.Country
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            SpaceViewModel model = new SpaceViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SpaceViewModel model)
        {
            var dto = new SpaceShipDto()
            {
                Id = model.Id,
                Name = model.Name,
                Model = model.Model,
                Company = model.Company,
                EnginePower = model.EnginePower,
                Country = model.Country,
                LaunchDate = model.LaunchDate,
                CreatedAt = model.CreatedAt,
                ModifiedAt = model.ModifiedAt,
                Files = model.Files,
                ExistingFilePaths = model.ExistingFilePaths.Select(x => new ExistingFilePathDto
                {
                    
                }).ToArray()
            };

            var result = await _SpaceShipService.Add(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var SpaceShip = await _SpaceShipService.Delete(id);
            if (SpaceShip == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var spaceship = await _SpaceShipService.GetAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var model = new SpaceViewModel();

            model.Id = spaceship.Id;
            model.Name = spaceship.Name;
            model.Model = spaceship.Model;
            model.Company = spaceship.Company;
            model.EnginePower = spaceship.EnginePower;
            model.Country = spaceship.Country;
            model.LaunchDate = spaceship.LaunchDate;
            model.ModifiedAt = spaceship.ModifiedAt;
            model.CreatedAt = spaceship.CreatedAt;
            

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SpaceViewModel model)
        {
            var dto = new SpaceShipDto()
            {
                Id = model.Id,
                Name = model.Name,
                Model = model.Model,
                Company = model.Company,
                EnginePower = model.EnginePower,
                Country = model.Country,
                LaunchDate = model.LaunchDate,
                CreatedAt = model.CreatedAt,
                ModifiedAt = model.ModifiedAt,
                Files = model.Files,
                
                    
            };

            var result = await _SpaceShipService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), model);
        }

    }
}

