using AccessHomes.Domain.Common;
using AccessHomes.Domain.Entities;
using AccessHomes.Service.DTO.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessHomes.Service.Contract
{
    public interface IAmenitiesRepo
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<Amenities>> GetAllAmenities();
        Task<Amenities> GetAmenitiesById(int id);

        IEnumerable<Amenities> GetAmenitiesByPropertyId(int id);
        Task CreateAmenities(Amenities amenity);
        void UpdateAmenities(Amenities amenity);
        void DeleteAmenities(Amenities amenity);
    }
}
