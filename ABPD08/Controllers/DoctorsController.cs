using ABPD08.Models;
using ABPD08.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ABPD08.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private IConfiguration Configuration { get; set; }
        private readonly ISqlServerDbService _dbService;

        public DoctorsController(ISqlServerDbService dbService, IConfiguration configuration)
        {
            _dbService = dbService;
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_dbService.GetDoctors());
        }

        [HttpPost]
        public IActionResult AddDoctor(Doctor doc)
        {
            return Ok(_dbService.AddDoctor(doc));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDoctor([FromRoute] int id, [FromBody] Doctor doctor)
        {
            return Ok(_dbService.UpdateDoctor(id, doctor));
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveDoctor([FromRoute] int id)
        {
            return Ok(_dbService.DeleteDoctor(id));
        }



    }
}