using AutoMapper;
using AccessHomes.Domain.Common;
using AccessHomes.Domain.Entities;
using AccessHomes.Service.Contract;
using AccessHomes.Service.DTO.Response;
using AccessHomes.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AccessHomes.Service.DTO.Request;
using Microsoft.AspNetCore.Identity;
using AccessHomes.Domain.Auth;
using AccessHomes.Domain.QueryParameters;
using Hangfire;

namespace AccessHomes.Service.Implementation
{
    public class Repository : IRepository
    {
        private readonly IDBFactory _dbFactory;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IClientFactory _clientFactory;
        private readonly IMapper _mapper;
        private readonly string _baseUrl;

        public Repository(IDBFactory dbFactory,
            UserManager<ApplicationUser> userManager,
            IClientFactory clientFactory,
            IMapper mapper,
            IConfiguration configuration)
        {
            _dbFactory = dbFactory;
            _userManager = userManager;
            _clientFactory = clientFactory;
            _mapper = mapper;
            _baseUrl = configuration["APISettings:SampleApi"];
        }

        /*******************************************************************************************************/
        //To be deleted
        public async Task<Response<IEnumerable<PersonQueryResponse>>> GetPersons()
        {
            var data = await _dbFactory.GetAllPersonAsync();
            var persons = _mapper.Map<IEnumerable<PersonQueryResponse>>(data);

            return new Response<IEnumerable<PersonQueryResponse>>(persons, message: "Successfully retrieved all persons.");
        }

        public async Task<Response<PersonQueryResponse>> GetPersonById(long id)
        {
            var person = await _dbFactory.GetByIdAsync(id);
            PersonQueryResponse response = new PersonQueryResponse();

            if (person != null)
            {
                response = _mapper.Map<PersonQueryResponse>(person);
            }
            else
            {
                throw new ApiException($"Record with id: {id} does not exist.");
            }
            return new Response<PersonQueryResponse>(response, message: $"Successfully retrieved person with id - {id}.");
        }

        public async Task<Response<List<Student>>> GetStudents()
        {
            var person = await _clientFactory.GetDataAsync<List<StudentQueryResponse>>($"{_baseUrl}/api/users");
            List<Student> response = new List<Student>();

            if (person != null)
            {
                response = _mapper.Map<List<Student>>(person);
            }
            else
            {
                throw new ApiException($"No student exist in the school.");
            }
            return new Response<List<Student>>(response, message: $"Successfully retrieved students information.");
        }

        //To be deleted
        /*******************************************************************************************************/
        public async Task<Response<string>> AddRatings(AddRatingRequest request, string username)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(username);
            Ratings rating = new Ratings()
            {
                UserId = user.Id,
                PropertiesId = request.PropertiesId,
                Rating = request.Rating,
                Comment = request.Comment
            };

            long response = await _dbFactory.AddRatingAsync(rating);
            RecalculateRatings(rating);

            if (response >= 1)
            {
                return new Response<string>(message: $"Successfully added property rating.");
            }
            else
            {
                throw new ApiException($"Failed to add property rating.");
            }
        }

        private async void RecalculateRatings(Ratings request)
        {
            CumulativeRating oldRating = await _dbFactory.GetRatingByPropertyId(request.PropertiesId);
            CumulativeRating rating = new CumulativeRating() {
                PropertiesId = request.PropertiesId
            };

            if (oldRating == null)
            {
                rating.AverageRating = request.Rating;
                rating.Count = 1;

                _dbFactory.AddRecalculatedRating(rating);
            }
            else
            {
                int newCount = oldRating.Count + 1;
                double avgRating = ((oldRating.AverageRating * oldRating.Count) + request.Rating) / (newCount);

                rating.Id = oldRating.Id;
                rating.AverageRating = avgRating;
                rating.Count = newCount;

                _dbFactory.UpdateRecalculatedRating(rating);
            }
        }

        public async Task<Response<CumulativeRating>> GetRatingByPropertyId(int propertyId)
        {
            CumulativeRating response = await _dbFactory.GetRatingByPropertyId(propertyId);

            if (response != null)
            {
                return new Response<CumulativeRating>(response, message: $"Successfully retrieved property rating.");
            }
            else
            {
                throw new ApiException($"Failed to retrieve property rating.");
            }
        }

        public async Task<Response<string>> AddInspection(AddInspectionRequest request, string username)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(username);
            Inspection inspectionVisit = new Inspection()
            {
                UserId = user.Id,
                PropertiesId = request.PropertiesId,
                Date = request.Date,
                Comments = request.Comments
            };

            long response = await _dbFactory.AddInspectionAsync(inspectionVisit);

            if (response >= 1)
            {
                var emailRequest = new EmailRequest()
                {
                    Recipient = "falugbao@accessbankplc.com",
                    Subject = "Test Email",
                    Content = "<p>Dear Custodian,</p><p>This is a test email to confirm that this service works.</p><p>Regards,</p><h3><strong>Thelma</strong></h3>"
                };

                var smsRequest = new SMSRequest()
                {
                    ReceiverNumber = "08087901155",
                    SMSMessage = "Dear Custodian, this is a test SMS to confirm that this service works."
                };

                BackgroundJob.Enqueue<INotificationService>(x => x.SendEmail(emailRequest));
                BackgroundJob.Enqueue<INotificationService>(x => x.SendSMS(smsRequest));
                return new Response<string>(message: $"Successfully booked a date for inspection.");
            }
            else
            {
                throw new ApiException($"Failed to book a date for property inspection.");
            }
        }

        public async Task<Response<string>> AddInspection(AddInspectionRequest request)
        {
            Inspection inspectionVisit = new Inspection()
            {
                PropertiesId = request.PropertiesId,
                Name = request.Name,
                Email = request.Email,
                Date = request.Date,
                Comments = request.Comments
            };

            long response = await _dbFactory.AddInspectionAsync(inspectionVisit);

            if (response >= 1)
            {
                var emailRequest = new EmailRequest()
                {
                    Recipient = "falugbao@accessbankplc.com",
                    Subject = "Test Email",
                    Content = "<p>Dear Custodian,</p><p>This is a test email to confirm that this service works.</p><p>Regards,</p><h3><strong>Thelma</strong></h3>"
                };

                var smsRequest = new SMSRequest()
                {
                    ReceiverNumber = "08087901155",
                    SMSMessage = "Dear Custodian, this is a test SMS to confirm that this service works."
                };

                BackgroundJob.Enqueue<INotificationService>(x => x.SendEmail(emailRequest));
                BackgroundJob.Enqueue<INotificationService>(x => x.SendSMS(smsRequest));
                return new Response<string>(message: $"Successfully booked a date for inspection.");
            }
            else
            {
                throw new ApiException($"Failed to book a date for property inspection.");
            }
        }

        public async Task<Response<IEnumerable<Inspection>>> GetInspectionAsync(InspectionQueryParameters query)
        {
            (IEnumerable<Inspection> Inspections, Pagination Pagination) response = await _dbFactory.GetInspectionAsync(query);

            if (response.Inspections != null)
            {
                if (query.StartDate.HasValue && query.EndDate.HasValue)
                {
                    response.Inspections = response.Inspections.Where(x => query.StartDate.Value.AddDays(-1) <= x.Date && x.Date <= query.EndDate.Value.AddDays(1));
                }
                return new Response<IEnumerable<Inspection>>(response.Inspections, response.Pagination, message: $"Successfully retrieved property inspections.");
            }
            else
            {
                throw new ApiException($"Failed to retrieve property inspections.");
            }
        }
    }
}
