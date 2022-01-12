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
    public class CarServices : ICarService
    {
        private readonly ShopDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IFileServices _fileServices;

        public CarServices
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

        public async Task<Cars> Add(CarsDto dto)
        {
            Cars cars = new Cars();

            cars.Id = Guid.NewGuid();
            cars.Mark = dto.Mark;
            cars.Series = dto.Series;
            cars.Price = dto.Price;
            cars.Weight = dto.Weight;
            cars.CreatedAt = DateTime.Now;
            cars.ModifiedAt = DateTime.Now;
            _fileServices.ProcessUploadFile(dto, cars);

            await _context.Cars.AddAsync(cars);
            await _context.SaveChangesAsync();

            return cars;
        }


        public async Task<Cars> Delete(Guid id)
        {
            var CarId = await _context.Cars
                .Include(x => x.ExistingFilePaths)
                .FirstOrDefaultAsync(x => x.Id == id);

            var photos = await _context.ExistingFilePath
                .Where(x => x.CarId == id)
                .Select(y => new ExistingFilePathDto
                {
                    CarId = y.CarId,
                    ExistingFilePath = y.FilePath,
                    Id = y.Id
                })
                .ToArrayAsync();


            await _fileServices.RemoveImages(photos);
            _context.Cars.Remove(CarId);
            await _context.SaveChangesAsync();

            return CarId;
        }


        public async Task<Cars> Update(CarsDto dto)
        {
            Cars cars = new Cars();

            cars.Id = dto.Id;
            cars.Mark = dto.Mark;
            cars.Series = dto.Series;
            cars.Price = dto.Price;
            cars.Weight = dto.Weight;
            cars.CreatedAt = dto.CreatedAt;
            cars.ModifiedAt = DateTime.Now;
            _fileServices.ProcessUploadFile(dto, cars);

            _context.Cars.Update(cars);
            await _context.SaveChangesAsync();
            return cars;
        }

        public async Task<Cars> GetAsync(Guid id)
        {
            var result = await _context.Cars
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
