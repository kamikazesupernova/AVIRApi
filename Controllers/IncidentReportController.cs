using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AVIRApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AVIRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentReportController : ControllerBase
    {
        private readonly IncidentContext _context;
        private readonly IConfiguration _config;

        public IncidentReportController(IncidentContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
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

                var threat = new ThreatProfile()
                {
                   IncidentReportID = incidentReport.ID
                };

            _context.ThreatProfiles.Add(threat);

            await _context.SaveChangesAsync();

            UpdateThreatProfile(threat, incidentReport);
            CalculateScore(incidentReport);

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
        private async void UpdateThreatProfile(ThreatProfile threatProfile, IncidentReport incidentReport){
            //calculates the decay of attribute               
            System.Diagnostics.Debug.WriteLine(threatProfile.ID.ToString());
            
            var age = _context.IncidentReports
                    .Where(x => x.ID == threatProfile.IncidentReportID)
                    .Select(r => EF.Functions.DateDiffHour(r.DetectTime, DateTime.Now))
                    .FirstOrDefault();


            //finds the number of  hours since reports of this type were last seen
            var lastseen = _context.IncidentReports
                            .Where(typ => typ.Target.FirstOrDefault().Type == incidentReport.Target.FirstOrDefault().Type
                            && typ.Source.FirstOrDefault().IP4 == incidentReport.Source.FirstOrDefault().IP4)
                            .Select(r => EF.Functions.DateDiffHour(r.DetectTime, DateTime.Now)).Max();

        
           //count of recent occurrances
            var occurrances =_context.IncidentReports
                            .Where(typ => typ.Target.FirstOrDefault().Type == incidentReport.Target.FirstOrDefault().Type
                            && typ.Source.FirstOrDefault().IP4 == incidentReport.Target.FirstOrDefault().Type).Count();

            //count of location frequency 
            var location =_context.IncidentReports
                            .Where(n => n.Node.GPSLatitude == incidentReport.Node.GPSLatitude
                             && n.Node.GPSLongitude == incidentReport.Node.GPSLongitude)
                            .GroupBy(a => new {a.Node.GPSLatitude, a.Node.GPSLongitude})
                            .Count();

       
            //rv = await _context.IncidentReports.FromSqlRaw(sql).ToListAsync();

            var threatprofile = await _context.ThreatProfiles.FindAsync(threatProfile.ID);
            if (threatprofile != null){

                threatprofile.Age = Convert.ToInt32(age) * GetWeightage("Age")/100;
                threatprofile.LastSeen = Convert.ToInt32(lastseen) * GetWeightage("LastSeen")/100;
                threatprofile.NumOccurences = Convert.ToInt32(occurrances) * GetWeightage("NumOccurences")/100;
                threatprofile.LocationFrequency = Convert.ToInt32(location) * GetWeightage("LocationFrequency")/100;

               await _context.SaveChangesAsync();

            }

        }
    private async void CalculateScore(IncidentReport incidentReport){

            var threatprofile = await _context.ThreatProfiles.FindAsync(incidentReport.ID);
            if (threatprofile != null){

                threatprofile.Score = threatprofile.Age + threatprofile.LastSeen + threatprofile.NumOccurences + threatprofile.LocationFrequency;


               await _context.SaveChangesAsync();

            }
    }
    private int GetWeightage(string type){
      

       int result = Convert.ToInt32(_config.GetRequiredSection("Weightings").GetSection(type).Value);

       return result;

    }

    }
}
