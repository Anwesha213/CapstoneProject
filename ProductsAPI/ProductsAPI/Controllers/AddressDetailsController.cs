using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressDetailsController : ControllerBase
    {
        private readonly ProductsDbContext _context;

        public AddressDetailsController(ProductsDbContext context)
        {
            _context = context;
        }

        // GET: api/AddressDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDetails>>> GetAddressDetails()
        {
            return await _context.AddressDetails.ToListAsync();
        }

        // GET: api/AddressDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDetails>> GetAddressDetails(int id)
        {
            var addressDetails = await _context.AddressDetails.FindAsync(id);

            if (addressDetails == null)
            {
                return NotFound();
            }

            return addressDetails;
        }

        // PUT: api/AddressDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddressDetails(int id, AddressDetails addressDetails)
        {
            if (id != addressDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(addressDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AddressDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AddressDetails>> PostAddressDetails(AddressDetails addressDetails)
        {
            _context.AddressDetails.Add(addressDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddressDetails", new { id = addressDetails.Id }, addressDetails);
        }

        // DELETE: api/AddressDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AddressDetails>> DeleteAddressDetails(int id)
        {
            var addressDetails = await _context.AddressDetails.FindAsync(id);
            if (addressDetails == null)
            {
                return NotFound();
            }

            _context.AddressDetails.Remove(addressDetails);
            await _context.SaveChangesAsync();

            return addressDetails;
        }

        private bool AddressDetailsExists(int id)
        {
            return _context.AddressDetails.Any(e => e.Id == id);
        }
    }
}
