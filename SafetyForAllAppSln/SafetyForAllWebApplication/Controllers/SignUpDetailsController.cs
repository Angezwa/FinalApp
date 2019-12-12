using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafetyForAllWebApplication.Models;

namespace SafetyForAllWebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SignUpDetailsController : ControllerBase
    {
        private readonly DetailsContext _context;

        public SignUpDetailsController(DetailsContext context)
        {
            _context = context;
        }

        // GET: api/SignUpDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SignUpDetail>>> GetSignUpDetails()
        {
            return await _context.SignUpDetails.ToListAsync();
        }

        // GET: api/SignUpDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SignUpDetail>> GetSignUpDetail(int id)
        {
            var signUpDetail = await _context.SignUpDetails.FindAsync(id);

            if (signUpDetail == null)
            {
                return NotFound();
            }

            return signUpDetail;
        }

        // PUT: api/SignUpDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSignUpDetail(int id, SignUpDetail signUpDetail)
        {
            if (id != signUpDetail.ID)
            {
                return BadRequest();
            }

            _context.Entry(signUpDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignUpDetailExists(id))
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

        // POST: api/SignUpDetails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SignUpDetail>> PostSignUpDetail(SignUpDetail signUpDetail)
        {
            _context.SignUpDetails.Add(signUpDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSignUpDetail", new { id = signUpDetail.ID }, signUpDetail);
        }

        // DELETE: api/SignUpDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SignUpDetail>> DeleteSignUpDetail(int id)
        {
            var signUpDetail = await _context.SignUpDetails.FindAsync(id);
            if (signUpDetail == null)
            {
                return NotFound();
            }

            _context.SignUpDetails.Remove(signUpDetail);
            await _context.SaveChangesAsync();

            return signUpDetail;
        }

        private bool SignUpDetailExists(int id)
        {
            return _context.SignUpDetails.Any(e => e.ID == id);
        }
    }
}
