using Customer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInfoController : ControllerBase
    {
        private readonly CustomerDbContext _context;

        public CustomerInfoController(CustomerDbContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customerInfos = await _context.Customers.ToListAsync();
            return Ok(customerInfos);
        }

        // POST OR INSERT
        [HttpPost]
        public async Task<IActionResult> Create(CustomerInfo customerInfo)
        {
            _context.Customers.Add(customerInfo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = customerInfo.Id }, customerInfo);
        }

        // GET ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customerInfo = await _context.Customers.FindAsync(id);
            if (customerInfo == null)
            {
                return NotFound();
            }
            return Ok(customerInfo);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customerInfo = await _context.Customers.FindAsync(id);
            if (customerInfo == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customerInfo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
