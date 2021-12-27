using AccessHomes.Domain.Common;
using AccessHomes.Domain.Entities;
using AccessHomes.Domain.QueryParameters;
using AccessHomes.Service.DTO.Request;
using AccessHomes.Service.DTO.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessHomes.Service.Contract
{
    public interface IRepository
    {
        Task<Response<string>> AddRatings(AddRatingRequest request, string username);
        Task<Response<CumulativeRating>> GetRatingByPropertyId(int propertyId);
        Task<Response<string>> AddInspection(AddInspectionRequest request, string username);
        Task<Response<string>> AddInspection(AddInspectionRequest request);

        Task<Response<IEnumerable<Inspection>>> GetInspectionAsync(InspectionQueryParameters query);

        Task<Response<IEnumerable<PersonQueryResponse>>> GetPersons();
        Task<Response<PersonQueryResponse>> GetPersonById(long id);
        Task<Response<List<Student>>> GetStudents();

    }
}
