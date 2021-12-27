using AccessHomes.Domain.Entities;
using AccessHomes.Persistence;
using AccessHomes.Service.Contract;
using AccessHomes.Service.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccessHomes.Service.Implementation
{ 
    public class AmenitiesRepo : IAmenitiesRepo
    {
        private readonly IApplicationDbContext _context;

        public AmenitiesRepo(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAmenities(Amenities amenities)
        {
            if (amenities == null)
            {
                throw new ApiException($"Please enter amenity details");
            }

            await _context.Amenities.AddAsync(amenities);
        }

        public void DeleteAmenities(Amenities amenities)
        {
            if (amenities == null)
            {
                throw new ApiException($"Error deleting Amenities");
            }
            _context.Amenities.Remove(amenities);
        }

        public async Task<IEnumerable<Amenities>> GetAllAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenities> GetAmenitiesById(int id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(p => p.Id == id);
        }

        public IEnumerable<Amenities> GetAmenitiesByPropertyId(int id)
        {
            return _context.Amenities.Where(p => p.PropertiesId == id);
        }
        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateAmenities(Amenities amenities)
        {
            //Nothing
        }
    }
}
