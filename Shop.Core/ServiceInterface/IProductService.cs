using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ServiceInterface
{
    public interface IProductService : IApplicationService
    {
        Task<Product> Add(ProductDto dto);

        Task<Product> Delete(Guid id);

        Task<Product> Update(ProductDto dto);

        Task<Product> GetAsync(Guid id);

        //Task<ExistingFilePath> RemoveImage(ExistingFilePathDto dto);
    }
}
