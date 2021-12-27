using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AccessHomes.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessHomes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class APITestController : ControllerBase
    {
       
        private readonly IRepository _repository;
        public APITestController(IRepository repository)
        {
            _repository = repository;
        } 

        

        [HttpGet("get-students")]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await _repository.GetStudents());
        }
    }
}
