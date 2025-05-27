using Microsoft.AspNetCore.Mvc;
using OTF_System.Models;
using OTF_System.Services;
using OTF_System.Models;
using OTF_System.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OTF_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        // GET: api/driver
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetAllDrivers()
        {
            var drivers = await _driverService.GetAllDriversAsync();
            return Ok(drivers);
        }

        // GET: api/driver/{licenceNo}
        [HttpGet("{licenceNo}")]
        public async Task<ActionResult<Driver>> GetDriver(string licenceNo)
        {
            var driver = await _driverService.GetDriverByLicenceNoAsync(licenceNo);
            if (driver == null)
            {
                return NotFound();
            }
            return Ok(driver);
        }

        // POST: api/driver
        [HttpPost]
        public async Task<ActionResult> AddDriver([FromBody] Driver driver)
        {
            await _driverService.AddDriverAsync(driver);
            return CreatedAtAction(nameof(GetDriver), new { licenceNo = driver.LicenceNo }, driver);
        }

        // PUT: api/driver/{licenceNo}
        [HttpPut("{licenceNo}")]
        public async Task<ActionResult> UpdateDriver(string licenceNo, [FromBody] Driver driver)
        {
            if (licenceNo != driver.LicenceNo)
            {
                return BadRequest("Licence number mismatch.");
            }

            var existingDriver = await _driverService.GetDriverByLicenceNoAsync(licenceNo);
            if (existingDriver == null)
            {
                return NotFound();
            }

            await _driverService.UpdateDriverAsync(driver);
            return NoContent();
        }

        // DELETE: api/driver/{licenceNo}
        [HttpDelete("{licenceNo}")]
        public async Task<ActionResult> DeleteDriver(string licenceNo)
        {
            var deleted = await _driverService.DeleteDriverAsync(licenceNo);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
