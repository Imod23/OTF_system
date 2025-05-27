using Microsoft.AspNetCore.Mvc;
using OTF_System.Models;
using OTF_System.Services;
using OTF_System.Models;
using OTF_System.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sachintha.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FineController : ControllerBase
    {
        private readonly IFineService _fineService;

        public FineController(IFineService fineService)
        {
            _fineService = fineService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fine>>> GetAll()
        {
            return Ok(await _fineService.GetAllFinesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fine>> Get(string id)
        {
            var fine = await _fineService.GetFineByIdAsync(id);
            if (fine == null) return NotFound();
            return Ok(fine);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Fine fine)
        {
            await _fineService.AddFineAsync(fine);
            return CreatedAtAction(nameof(Get), new { id = fine.FineID }, fine);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Fine fine)
        {
            if (id != fine.FineID)
                return BadRequest("Fine ID mismatch.");

            await _fineService.UpdateFineAsync(fine);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _fineService.DeleteFineAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
