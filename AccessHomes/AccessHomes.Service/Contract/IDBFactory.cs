using AccessHomes.Domain.Common;
using AccessHomes.Domain.Entities;
using AccessHomes.Domain.QueryParameters;
using AccessHomes.Service.DTO.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessHomes.Service.Contract
{
    public interface IDBFactory
    {
        Task<long> AddRatingAsync(Ratings rating);
        Task<CumulativeRating> GetRatingByPropertyId(int PropertiesId);
        void AddRecalculatedRating(CumulativeRating rating);
        void UpdateRecalculatedRating(CumulativeRating rating);
        Task<long> AddInspectionAsync(Inspection inspection);
        Task<(IEnumerable<Inspection> Inspections, Pagination Pagination)> GetInspectionAsync(InspectionQueryParameters queryParameters);


        Task<IEnumerable<Person>> GetAllPersonAsync();
        Task<Person> GetByIdAsync(object id);
        Task<long> CreateAsync(Person entity);
        Task<bool> UpdateAsync(Person entity);
        Task<bool> DeleteAsync(object id);
        Task<bool> ExistAsync(object id);
    }
}
