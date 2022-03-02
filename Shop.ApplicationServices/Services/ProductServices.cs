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
using Shop.Core.Dto;

namespace Shop.ApplicationServices.Services
{
    public class ProductServices : IProductService
    {
        private readonly ShopDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IFileServices _fileServices;

        public ProductServices
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

        public async Task<Product> Add(ProductDto dto)
        {
            Product product = new Product();

            product.Id = Guid.NewGuid();
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Value = dto.Value;
            product.Weight = dto.Weight;
            product.CreatedAt = DateTime.Now;
            product.ModifiedAt = DateTime.Now;
            _fileServices.ProcessUploadFile(dto, product);

            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }


        public async Task<Product> Delete(Guid id)
        {
            var productId = await _context.Product
                .Include(x => x.ExistingFilePaths)
                .FirstOrDefaultAsync(x => x.Id == id);

            var photos = await _context.ExistingFilePath
                .Where(x => x.ProductId == id)
                .Select(y => new ExistingFilePathDto
                {
                    ProductId = y.ProductId,
                    ExistingFilePath = y.FilePath,
                    Id = y.Id
                })
                .ToArrayAsync();


            await _fileServices.RemoveImages(photos);
            _context.Product.Remove(productId);
            await _context.SaveChangesAsync();

            return productId;
        }


        public async Task<Product> Update(ProductDto dto)
        {
            Product product = new Product();

            product.Id = dto.Id;
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Value = dto.Value;
            product.Weight = dto.Weight;
            product.CreatedAt = dto.CreatedAt;
            product.ModifiedAt = DateTime.Now;
            _fileServices.ProcessUploadFile(dto, product);

            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetAsync(Guid id)
        {
            var result = await _context.Product
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
