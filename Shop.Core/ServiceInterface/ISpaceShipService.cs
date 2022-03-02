using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ServiceInterface
{
    public interface ISpaceshipService : IApplicationService
    {
        Task<Spaceship> Add(SpaceshipDto dto);
        Task<Spaceship> Delete(Guid id);
        Task<Spaceship> Update(SpaceshipDto dto);
        Task<Spaceship> GetAsync(Guid id);
        Task<FileToDatabase> RemoveImage(FileToDatabaseDto dto);
    }
}
