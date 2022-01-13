using Shop.Core.Domain;
using Shop.Core.Dtos;
using Shop.Data;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Core.ServiceInterface;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace Shop.ApplicationServices.Services
{
    public class SpaceShipServices : ISpaceShipService
    {
        private readonly ShopDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IFileServices _fileServices;

        public SpaceShipServices
            (
            ShopDbContext context,
            IWebHostEnvironment env,
            IFileServices fileServices
            )
        {
            _context = context;
            _env = env;
            _fileServices = fileServices;
        }

        public async Task<SpaceShip> Add(SpaceShipDto dto)
        {
            SpaceShip spaceship = new SpaceShip();

            spaceship.Id = Guid.NewGuid();
            spaceship.Name = dto.Name;
            spaceship.Model = dto.Model;
            spaceship.Company = dto.Company;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.Country = dto.Country;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;
            _fileServices.ProcessUploadFile(dto, spaceship);

            await _context.SpaceShips.AddAsync(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;
        }


        public async Task<SpaceShip> Delete(Guid id)
        {
            var SpaceShipId = await _context.SpaceShips
                .FirstOrDefaultAsync(x => x.Id == id);


            _context.SpaceShips.Remove(SpaceShipId);
            await _context.SaveChangesAsync();

            return SpaceShipId;
        }


        public async Task<SpaceShip> Update(SpaceShipDto dto)
        {
            SpaceShip spaceship = new SpaceShip();

            spaceship.Name = dto.Name;
            spaceship.Model = dto.Model;
            spaceship.Company = dto.Company;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.Country = dto.Country;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;
            _fileServices.ProcessUploadFile(dto, spaceship);

            _context.SpaceShips.Update(spaceship);
            await _context.SaveChangesAsync();
            return spaceship;
        }

        public async Task<SpaceShip> GetAsync(Guid id)
        {
            var result = await _context.SpaceShips
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        //public string ProcessUploadFile(ProductDto dto, Product product)
        //{
        //    string uniqueFileName = null;

        //    if(dto.Files != null && dto.Files.Count > 0)
        //    {
        //        if(!Directory.Exists(_env.WebRootPath + "\\multipleFileUpload\\"))
        //        {
        //            Directory.CreateDirectory(_env.WebRootPath + "\\multipleFileUpload\\");
        //        }

        //        foreach (var photo in dto.Files)
        //        {
        //            string uploadsFolder = Path.Combine(_env.WebRootPath, "multipleFileUpload");
        //            uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
        //            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                photo.CopyTo(fileStream);

        //                ExistingFilePath path = new ExistingFilePath
        //                {
        //                    Id = Guid.NewGuid(),
        //                    FilePath = uniqueFileName,
        //                    ProductId = product.Id
        //                };

        //                _context.ExistingFilePath.Add(path);
        //            }
        //        }
        //    }

        //    return uniqueFileName;
        //}


        //public async Task<ExistingFilePath> RemoveImage(ExistingFilePathDto dto)
        //{
        //    var photoId = await _context.ExistingFilePath
        //        .FirstOrDefaultAsync(x => x.Id == dto.Id);

        //    _context.ExistingFilePath.Remove(photoId);
        //    await _context.SaveChangesAsync();

        //    return photoId;
        //}
    }
}
