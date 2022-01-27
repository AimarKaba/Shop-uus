using Shop.Core.Domain;
using Shop.Core.Dtos;
using Shop.Data;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Core.ServiceInterface;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.IO;

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
            FileToDatabase file = new FileToDatabase();

            spaceship.Id = Guid.NewGuid();
            spaceship.Name = dto.Name;
            spaceship.Model = dto.Model;
            spaceship.Company = dto.Company;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.Country = dto.Country;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            if (dto.Files != null)
            {
                file.ImageData = UploadFile(dto, spaceship);
            }


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
            FileToDatabase file = new FileToDatabase();

            spaceship.Id = dto.Id;
            spaceship.Name = dto.Name;
            spaceship.Model = dto.Model;
            spaceship.Company = dto.Company;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.Country = dto.Country;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            if (dto.Files != null)
            {
                file.ImageData = UploadFile(dto, spaceship);
            }

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
        public byte[] UploadFile(SpaceShipDto dto, SpaceShip spaceship)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var photo in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase objFiles = new FileToDatabase
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = photo.FileName,
                            SpaceShipId = spaceship.Id,
                        };

                        photo.CopyTo(target);
                        objFiles.ImageData = target.ToArray();

                        _context.FileToDatabase.Add(objFiles);
                    }
                }
            }
            return null;
        }
    }
}
                        

            
