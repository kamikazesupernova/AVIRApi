using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AVIRApi.Models;

namespace AVIRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreatProfileController : ControllerBase
    {
        private readonly IncidentContext _context;

        public ThreatProfileController(IncidentContext context)
        {
            _context = context;
        }

        // GET: api/ThreatProfile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThreatProfile>>> GetThreatProfiles()
        {
            return await _context.ThreatProfiles.ToListAsync();
        }

        // GET: api/ThreatProfile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThreatProfile>> GetThreatProfile(Guid id)
        {
            var threatProfile = await _context.ThreatProfiles.FindAsync(id);

            if (threatProfile == null)
            {
                return NotFound();
            }

            return threatProfile;
        }

        // PUT: api/ThreatProfile/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThreatProfile(Guid id, ThreatProfile threatProfile)
        {
            if (id != threatProfile.ID)
            {
                return BadRequest();
            }

            _context.Entry(threatProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThreatProfileExists(id))
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

        // POST: api/ThreatProfile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThreatProfile>> PostThreatProfile(ThreatProfile threatProfile)
        {
            _context.ThreatProfiles.Add(threatProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThreatProfile", new { id = threatProfile.ID }, threatProfile);
        }

        // DELETE: api/ThreatProfile/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThreatProfile(Guid id)
        {
            var threatProfile = await _context.ThreatProfiles.FindAsync(id);
            if (threatProfile == null)
            {
                return NotFound();
            }

            _context.ThreatProfiles.Remove(threatProfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThreatProfileExists(Guid id)
        {
            return _context.ThreatProfiles.Any(e => e.ID == id);
        }
    }
}
