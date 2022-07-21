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
    public class IncidentReportController : ControllerBase
    {
        private readonly IncidentContext _context;

        public IncidentReportController(IncidentContext context)
        {
            _context = context;
        }

        // GET: api/IncidentReport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentReport>>> GetIncidentReports()
        {
          if (_context.IncidentReports == null)
          {
              return NotFound();
          }
            return await _context.IncidentReports.ToListAsync();
        }

        // GET: api/IncidentReport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentReport>> GetIncidentReport(Guid id)
        {
          if (_context.IncidentReports == null)
          {
              return NotFound();
          }
            var incidentReport = await _context.IncidentReports.FindAsync(id);

            if (incidentReport == null)
            {
                return NotFound();
            }

            return incidentReport;
        }
        
        // PUT: api/IncidentReport/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidentReport(Guid id, IncidentReport incidentReport)
        {
            if (id != incidentReport.ID)
            {
                return BadRequest();
            }

            _context.Entry(incidentReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentReportExists(id))
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

        // POST: api/IncidentReport
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IncidentReport>> PostIncidentReport(IncidentReport incidentReport)
        {
          if (_context.IncidentReports == null)
          {
              return Problem("Entity set 'IncidentContext.IncidentReports'  is null.");
          }
            _context.IncidentReports.Add(incidentReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIncidentReport), new { id = incidentReport.ID }, incidentReport);
        }

        // DELETE: api/IncidentReport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncidentReport(Guid id)
        {
            if (_context.IncidentReports == null)
            {
                return NotFound();
            }
            var incidentReport = await _context.IncidentReports.FindAsync(id);
            if (incidentReport == null)
            {
                return NotFound();
            }

            _context.IncidentReports.Remove(incidentReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncidentReportExists(Guid id)
        {
            return (_context.IncidentReports?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
