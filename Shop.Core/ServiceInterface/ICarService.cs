using Shop.Core.Domain;
using Shop.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ServiceInterface
{
    public interface ICarService : IApplicationService
    {
        Task<Cars> Add(CarsDto dto);

        Task<Cars> Delete(Guid id);

        Task<Cars> Update(CarsDto dto);

        Task<Cars> GetAsync(Guid id);

        //Task<ExistingFilePath> RemoveImage(ExistingFilePathDto dto);
    }
}
