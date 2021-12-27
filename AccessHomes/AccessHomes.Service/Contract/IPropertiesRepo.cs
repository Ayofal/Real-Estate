using AccessHomes.Domain.Common;
using AccessHomes.Domain.Entities;
using AccessHomes.Domain.Enum;
using AccessHomes.Domain.QueryParameters;
using AccessHomes.Domain.Settings;
using AccessHomes.Service.DTO.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessHomes.Service.Contract
{
    public interface IPropertiesRepo
    {
        Task<bool> SaveChanges();



        Task<PagedList<Properties>> GetAllProperties(PaginationParams page);
        Task<Properties> GetPropertiesById(int id);
        Task CreateProperties(Properties property);
        void UpdateProperties(Properties property);
        void DeleteProperties(Properties property);
        Task<PagedList<Properties>> Search(PropertyQueryParameters property,PaginationParams page,List<AmenityQueryParameters> amenities);

    }
}
