using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AccessHomes.Domain.Common;
using AccessHomes.Domain.Entities;
using AccessHomes.Persistence;
using AccessHomes.Service.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using AccessHomes.Service.Exceptions;
using AccessHomes.Domain.QueryParameters;

namespace AccessHomes.Service.Implementation
{
    public class DBFactory : DbFactoryBase, IDBFactory
    {
        private readonly ILogger<DBFactory> _logger;
        public DBFactory(IConfiguration config, ILogger<DBFactory> logger) : base(config)
        {
            _logger = logger;
        }

        public async Task<long> AddRatingAsync(Ratings rating)
        {
            try
            {
                string sqlQuery = $@"INSERT INTO Ratings(UserId, PropertiesId, Rating, Comment)
                                     VALUES(@UserId, @PropertiesId, @Rating, @Comment)
                                     SELECT CAST(SCOPE_IDENTITY() as bigint)";

                return await DbQuerySingleAsync<long>(sqlQuery, rating);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error adding rating for user - {rating.UserId} :: Exception - {ex.Message}");
                throw new ApiException($"Failed to add property rating.");
            }
        }

        public async Task<CumulativeRating> GetRatingByPropertyId(int PropertiesId)
        {
            return await DbQuerySingleAsync<CumulativeRating>("SELECT * FROM CumulativeRating WHERE PropertiesId = @PropertiesId", new { PropertiesId });
        }

        public async void AddRecalculatedRating(CumulativeRating rating)
        {
            try
            {
                string sqlQuery = $@"INSERT INTO CumulativeRating(PropertiesId, AverageRating, Count)
                                     VALUES(@PropertiesId, @AverageRating, @Count)
                                     SELECT CAST(SCOPE_IDENTITY() as bigint)";

                var response = await DbQuerySingleAsync<long>(sqlQuery, rating);
                _logger.LogInformation($"Property rating recalculation response - {response} :: Property {rating.PropertiesId}");
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error adding recalculated rating for property - {rating.PropertiesId} :: Exception - {ex.Message}");
            }
        }

        public async void UpdateRecalculatedRating(CumulativeRating rating)
        {
            try
            {
                string sqlQuery = $@"IF EXISTS (SELECT 1 FROM CumulativeRating WHERE Id = @Id) 
                                            UPDATE CumulativeRating SET PropertiesId = @PropertiesId, AverageRating = @AverageRating, Count = @Count
                                            WHERE Id = @Id";

                bool response = await DbExecuteAsync<bool>(sqlQuery, rating);

                _logger.LogInformation($"Property rating recalculation response - {response} :: Property {rating.PropertiesId}");
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error adding recalculated rating for property - {rating.PropertiesId} :: Exception - {ex.Message}");
            }
        }

        public async Task<long> AddInspectionAsync(Inspection inspection)
        {
            try
            {
                string sqlQuery = $@"INSERT INTO Inspection(UserId, Name, Email, PropertiesId, Date, Comments)
                                     VALUES(@UserId, @Name, @Email, @PropertiesId, @Date, @Comments)
                                     SELECT CAST(SCOPE_IDENTITY() as bigint)";

                return await DbQuerySingleAsync<long>(sqlQuery, inspection);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error adding inspection for user - {inspection.PropertiesId} :: Exception - {ex.Message}");
                throw new ApiException($"Failed to add property inspection.");
            }
        }

        public async Task<(IEnumerable<Inspection> Inspections, Pagination Pagination)> GetInspectionAsync(InspectionQueryParameters queryParameters)
        {
            IEnumerable<Inspection> inspections;
            int recordCount = default;

            var query = @"SELECT * FROM Inspection WHERE PropertiesId = @PropertiesId
                            ORDER BY Id DESC
                            OFFSET @Limit * (@Offset -1) ROWS
                            FETCH NEXT @Limit ROWS ONLY";

            var param = new DynamicParameters();
            param.Add("Limit", queryParameters.PageSize);
            param.Add("Offset", queryParameters.PageNumber);
            param.Add("PropertiesId", queryParameters.PropertiesId);

            if (queryParameters.IncludeCount)
            {
                query += " SELECT COUNT(Id) FROM Inspection WHERE PropertiesId = @PropertiesId";
                var pagedRows = await DbQueryMultipleAsync<Inspection, int>(query, param);

                inspections = pagedRows.Data;
                recordCount = pagedRows.RecordCount;
            }
            else
            {
                inspections = await DbQueryAsync<Inspection>(query, param);
            }

            var metadata = new Pagination
            {
                PageNumber = queryParameters.PageNumber,
                PageSize = queryParameters.PageSize,
                TotalRecords = recordCount

            };

            return (inspections, metadata);

        }

        /**************************
         * To be deleted
         ***********************************/

        public async Task<IEnumerable<Person>> GetAllPersonAsync()
        {
            return await DbQueryAsync<Person>("SELECT * FROM Person");
        }

        public async Task<Person> GetByIdAsync(object id)
        {
            return await DbQuerySingleAsync<Person>("SELECT * FROM Person WHERE ID = @ID", new { id });
        }

        public async Task<long> CreateAsync(Person person)
        {
            string sqlQuery = $@"INSERT INTO Person (FirstName, LastName, DateOfBirth) 
                                     VALUES (@FirstName, @LastName, @DateOfBirth)
                                     SELECT CAST(SCOPE_IDENTITY() as bigint)";

            return await DbQuerySingleAsync<long>(sqlQuery, person);
        }
        public async Task<bool> UpdateAsync(Person person)
        {
            string sqlQuery = $@"IF EXISTS (SELECT 1 FROM Person WHERE ID = @ID) 
                                            UPDATE Person SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth
                                            WHERE ID = @ID";

            return await DbExecuteAsync<bool>(sqlQuery, person);
        }
        public async Task<bool> DeleteAsync(object id)
        {
            string sqlQuery = $@"IF EXISTS (SELECT 1 FROM Person WHERE ID = @ID)
                                        DELETE Person WHERE ID = @ID";

            return await DbExecuteAsync<bool>(sqlQuery, new { id });
        }
        public async Task<bool> ExistAsync(object id)
        {
            return await DbExecuteScalarAsync("SELECT COUNT(1) FROM Person WHERE ID = @ID", new { id });
        }

        /**************************
         * To be deleted
         ***********************************/
    }
}
