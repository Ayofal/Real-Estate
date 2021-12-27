using AccessHomes.Domain.Auth;
using AccessHomes.Domain.Entities;
using AccessHomes.Domain.QueryParameters;
using AccessHomes.Domain.Settings;
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
using AutoMapper;
using AccessHomes.Domain.Enum;
using Microsoft.AspNetCore.Http;

namespace AccessHomes.Service.Implementation
{
    public class PropertiesRepo:IPropertiesRepo
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PropertiesRepo(IApplicationDbContext context,IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateProperties(Properties properties)
        {
            if (properties == null)
            {
                throw new ApiException($"Please enter property details");
            }

            await _context.Properties.AddAsync(properties);
        }

        

        public void DeleteProperties(Properties properties)
        {
            if (properties == null)
            {
                throw new ApiException($"Error deleting properties");
            }
            _context.Properties.Remove(properties);
        }

        public async Task<PagedList<Properties>> GetAllProperties(PaginationParams page)
        {
            if (_httpContextAccessor.HttpContext.User.IsInRole(Roles.Admin.ToString()))
            {
                return await PagedList<Properties>.CreateAsync(_context.Properties
                    .Include(u => u.User)
                    .Include(at => at.Attachments)
                    .Include(am => am.Amenities),
                        page.PageNumber, page.PageSize);
            }
            else
            {
                return await PagedList<Properties>.CreateAsync(_context.Properties
                    .Where(p => p.IsEnabled == true)
                    .Include(u => u.User)
                    .Include(at => at.Attachments)
                    .Include(am => am.Amenities),
                        page.PageNumber, page.PageSize);
            }

        }

        public async Task<Properties> GetPropertiesById(int id)
        {
            if (_httpContextAccessor.HttpContext.User.IsInRole(Roles.Admin.ToString()))
            {
                return await _context.Properties
                .Include(u => u.User)
                .Include(at => at.Attachments)
                .Include(am => am.Amenities)
                .FirstOrDefaultAsync(p => p.Id == id);
            }
            else
            {
                return await _context.Properties
                .Where(p => p.IsEnabled == true)
                .Include(u => u.User)
                .Include(at => at.Attachments)
                .Include(am => am.Amenities)
                .FirstOrDefaultAsync(p => p.Id == id);
            }
                
        }

        

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
     

        public async Task<PagedList<Properties>> Search(PropertyQueryParameters property,PaginationParams page,List<AmenityQueryParameters> amenity)
        {
            IQueryable <Properties> query = _context.Properties.Where(p=>p.IsEnabled==false);
            var property_Amenities = _mapper.Map<IEnumerable<Amenities>>(amenity);



            List<Amenities> amenities = new List<Amenities>();
            foreach (var am in property_Amenities)
            {
                amenities.Add(_context.Amenities.Where(a => a.Amenity == am.Amenity).FirstOrDefault());

            }



            if (!string.IsNullOrEmpty(property.UserId))
            {
                query = query.Where(p=>p.UserId==property.UserId);
            }

            if (property.Status != null)
            {
                query = query.Where(p => p.Status == property.Status);
            }

            if (property.Type != null)
            {
                query = query.Where(p => p.Type == property.Type);
            }

            if (property.Bedrooms != null)
            {
                query = query.Where(p => p.Bedrooms == property.Bedrooms);
            }

            if (property.Bathrooms != null)
            {
                query = query.Where(p => p.Bathrooms == property.Bathrooms);
            }

            if (property.Country != null)
            {
                query = query.Where(p => p.Country == property.Country);
            }

            if (property.State != null)
            {
                query = query.Where(p => p.State == property.State);
            }

            if (property.City != null)
            {
                query = query.Where(p => p.City == property.City);
            }

            if (amenity != null)
            {
                //query = query.Where(p => p.Amenities.FirstOrDefault() == property_Amenities);
                //query = query.Where(p => p.Amenities == property_Amenities);
                //query = query.Where(p=>p.Amenities.Intersect(property_Amenities).Any());

                foreach (var propId in amenities)
                {
                    query = query.Where(p => p.Id ==propId.PropertiesId);
                }

            }

            if (property.DateFrom.HasValue && property.DateTo.HasValue)
            {
                query = query.Where(e => e.DateAdded >= property.DateFrom
                        && e.DateAdded <= property.DateTo);
            }
            else if (property.DateFrom.HasValue && !property.DateTo.HasValue)
            {
                query = query.Where(e => e.DateAdded >= property.DateFrom);

            }
            else if (property.DateTo.HasValue && !property.DateFrom.HasValue)
            {
                query = query.Where(e => e.DateAdded <= property.DateTo);
            }



            if (property.PriceFrom.HasValue&&property.PriceTo.HasValue)
            { 
                    
                query = query.Where(e => e.Price >= property.PriceFrom
                        && e.Price <= property.PriceTo);
            }
            else if(property.PriceFrom.HasValue&&!property.PriceTo.HasValue)
            {
                query = query.Where(e => e.Price >= property.PriceFrom);
                        
            }
            else if (property.PriceTo.HasValue && !property.PriceFrom.HasValue)
            {
                query = query.Where(e => e.Price <= property.PriceTo);
            }

            return await PagedList<Properties>.CreateAsync(query
                .Include(u => u.User)
                .Include(at => at.Attachments)
                .Include(am => am.Amenities),
                    page.PageNumber, page.PageSize);
        }

        public void UpdateProperties(Properties properties)
        {
            if (properties == null)
            {
                throw new ApiException($"Unable to find property details");
            }

            _context.Properties.Update(properties);
        }
    }
}
