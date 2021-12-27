using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AccessHomes.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccessHomes.Service.DTO.Request;

namespace AccessHomes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
       
        private readonly IRepository _repository;
        public RatingsController(IRepository repository)
        {
            _repository = repository;
        }

        [Authorize]
        [HttpPost("add-rating")]
        public async Task<IActionResult> AddRatingAsync(AddRatingRequest request)
        {
            string user = User.FindFirst("uname").Value;
            return Ok(await _repository.AddRatings(request, user));
        }

        [HttpGet("get-rating")]
        public async Task<IActionResult> GetRatingAsync([FromQuery] int id)
        {
            return Ok(await _repository.GetRatingByPropertyId(id));
        }
    }
}
