using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AccessHomes.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccessHomes.Service.DTO.Request;
using AccessHomes.Domain.Common;
using AccessHomes.Domain.QueryParameters;
using AccessHomes.Service.Exceptions;

namespace AccessHomes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionController : ControllerBase
    {
       
        private readonly IRepository _repository;
        public InspectionController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("add-inspection")]
        public async Task<IActionResult> AddInspectionAsync(AddInspectionRequest request)
        {
            if (request.Name is null || request.Email is null)
            {
                string user = User.FindFirst("uname").Value ?? throw new ApiException($"Kindly pass a name and email or authorize the user."); ;
                return Ok(await _repository.AddInspection(request, user));
            }
            return Ok(await _repository.AddInspection(request));
        }

        [HttpGet("get-inspection")]
        public async Task<IActionResult> GetInspectionAsync([FromQuery] InspectionQueryParameters query)
        {
            return Ok(await _repository.GetInspectionAsync(query));
        }
    }
}
