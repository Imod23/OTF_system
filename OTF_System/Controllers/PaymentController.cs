using Microsoft.AspNetCore.Mvc;
using OTF_System.Models;
using OTF_System.Models;
using Sachintha.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sachintha.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetAll()
        {
            return Ok(await _paymentService.GetAllPaymentsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> Get(string id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
                return NotFound();
            return Ok(payment);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Payment payment)
        {
            await _paymentService.AddPaymentAsync(payment);
            return CreatedAtAction(nameof(Get), new { id = payment.PaymentID }, payment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Payment payment)
        {
            if (id != payment.PaymentID)
                return BadRequest("ID mismatch");

            await _paymentService.UpdatePaymentAsync(payment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _paymentService.DeletePaymentAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
