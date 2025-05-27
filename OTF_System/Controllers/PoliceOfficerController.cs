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
    public class PoliceOfficerController : ControllerBase
    {
        private readonly IPoliceOfficerService _officerService;

        public PoliceOfficerController(IPoliceOfficerService officerService)
        {
            _officerService = officerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PoliceOfficer>>> GetAll()
        {
            return Ok(await _officerService.GetAllOfficersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PoliceOfficer>> Get(string id)
        {
            var officer = await _officerService.GetOfficerByIdAsync(id);
            if (officer == null) return NotFound();
            return Ok(officer);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PoliceOfficer officer)
        {
            await _officerService.AddOfficerAsync(officer);
            return CreatedAtAction(nameof(Get), new { id = officer.PoliceID }, officer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] PoliceOfficer officer)
        {
            if (id != officer.PoliceID)
                return BadRequest("ID mismatch");

            await _officerService.UpdateOfficerAsync(officer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _officerService.DeleteOfficerAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
