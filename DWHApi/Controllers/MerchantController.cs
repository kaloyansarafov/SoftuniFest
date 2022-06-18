using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DWHApi;
using DWHApi.Models;

namespace DWHApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly DWHDbContext _context;

        public MerchantController(DWHDbContext context)
        {
            _context = context;
        }
        
        // GET: api/Merchant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Merchant>>> GetMerchants()
        {
            return await _context.Merchants.ToListAsync();
        }
        
        // GET: api/Merchant
        [HttpGet("{pageSize}/{pageNumber}")]
        public async Task<ActionResult<IEnumerable<Merchant>>> GetMerchants(int pageSize, int pageNumber)
        {
            if (_context.Merchants == null)
            {
                return NotFound();
            }

            return await _context.Merchants.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        // GET: api/Merchant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Merchant>> GetMerchant(string id)
        {
            if (_context.Merchants == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchants.FindAsync(id);

            if (merchant == null)
            {
                return NotFound();
            }

            return merchant;
        }

        // PUT: api/Merchant/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMerchant(string id, Merchant merchant)
        {
            if (id != merchant.Id)
            {
                return BadRequest();
            }

            _context.Entry(merchant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MerchantExists(id))
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

        // POST: api/Merchant
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Merchant>> PostMerchant(Merchant merchant)
        {
            if (_context.Merchants == null)
            {
                return Problem("Entity set 'DWHDbContext.Merchants'  is null.");
            }

            //password hashing and verification
            var hasher = new PasswordHasher<Merchant>();
            var oldPassword = merchant.PasswordHash;
            var newPassword = hasher.HashPassword(merchant, oldPassword);
            var newPasswordVerify = hasher.VerifyHashedPassword(merchant, newPassword, oldPassword);

            if (newPasswordVerify == PasswordVerificationResult.Success)
            {
                merchant.PasswordHash = newPassword;
            }
            else
            {
                return BadRequest("Password hashing failed.");
            }

            _context.Merchants.Add(merchant);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MerchantExists(merchant.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMerchant", new { id = merchant.Id }, merchant);
        }

        // DELETE: api/Merchant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMerchant(string id)
        {
            if (_context.Merchants == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchants.FindAsync(id);
            if (merchant == null)
            {
                return NotFound();
            }

            _context.Merchants.Remove(merchant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MerchantExists(string id)
        {
            return (_context.Merchants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}