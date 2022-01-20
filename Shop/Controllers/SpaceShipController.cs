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

        public SpaceShipController
            (
            ShopDbContext context,
            ISpaceShipService SpaceShipService

            )
        {
            _context = context;
            _SpaceShipService = SpaceShipService;

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
        public async Task<IActionResult> Add(SpaceViewModel vm)
        {
            var dto = new SpaceShipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Model = vm.Model,
                Company = vm.Company,
                EnginePower = vm.EnginePower,
                Country = vm.Country,
                LaunchDate = vm.LaunchDate,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.Id,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    SpaceShipId = x.SpaceShipId
                }).ToArray()
            };

            var result = await _SpaceShipService.Add(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index", vm);
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
            var photos = await _context.FileToDatabase
                .Where(x => x.SpaceShipId == id)
                .Select(y => new ImageViewModel
                {
                    ImageData = y.ImageData,
                    Id = y.Id,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData)),
                    ImageTitle = y.ImageTitle,
                    SpaceShipId = y.Id
                }).ToArrayAsync();
                

            var vm = new SpaceViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Model = spaceship.Model;
            vm.Company = spaceship.Company;
            vm.EnginePower = spaceship.EnginePower;
            vm.Country = spaceship.Country;
            vm.LaunchDate = spaceship.LaunchDate;
            vm.ModifiedAt = spaceship.ModifiedAt;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.Image.AddRange(photos);
            

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SpaceViewModel vm)
        {
            var dto = new SpaceShipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Model = vm.Model,
                Company = vm.Company,
                EnginePower = vm.EnginePower,
                Country = vm.Country,
                LaunchDate = vm.LaunchDate,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto 
                {
                  Id = x.Id,
                  ImageData = x.ImageData,
                  ImageTitle = x.ImageTitle,
                  SpaceShipId = x.SpaceShipId,
                })
            };

            var result = await _SpaceShipService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

    }
}

