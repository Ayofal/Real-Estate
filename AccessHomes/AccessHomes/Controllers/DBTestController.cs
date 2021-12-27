using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AccessHomes.Service.Contract;
using System.Threading.Tasks;

namespace AccessHomes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DBTestController : ControllerBase
    {
        private readonly IRepository _repository;
        public DBTestController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("get-persons")]
        public async Task<IActionResult> GetPersons()
        {
            return Ok(await _repository.GetPersons());
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetPersonById([FromQuery] long id)
        {
            return Ok(await _repository.GetPersonById(id));
        }
    }
}