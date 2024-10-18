using Microsoft.AspNetCore.Mvc;
using System;

namespace Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController : Controller
    {
        private readonly AppDbContext _context;

        public CompetitorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/competitors
        [HttpGet]
        public async Task<IActionResult> GetCompetitors()
        {
            var competitors = await _context.Competitors.ToListAsync();
            return Ok(competitors);
        }

        // GET: api/competitors/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompetitor(int id)
        {
            var competitor = await _context.Competitors.FindAsync(id);
            if (competitor == null)
                return NotFound();
            return Ok(competitor);
        }

        // GET: api/competitors/categories/{categoryId}
        [HttpGet("categories/{categoryId}")]
        public async Task<IActionResult> GetCompetitorsByCategory(int categoryId)
        {
            var competitors = await _context.Competitors
                                            .Where(c => c.CategoryId == categoryId)
                                            .ToListAsync();
            return Ok(competitors);
        }

        // POST: api/competitors
        [HttpPost]
        public async Task<IActionResult> CreateCompetitor(Competitor competitor)
        {
            _context.Competitors.Add(competitor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCompetitor), new { id = competitor.Id }, competitor);
        }

        // PUT: api/competitors/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompetitor(int id, Competitor competitor)
        {
            if (id != competitor.Id)
                return BadRequest();

            _context.Entry(competitor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/competitors/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitor(int id)
        {
            var competitor = await _context.Competitors.FindAsync(id);
            if (competitor == null)
                return NotFound();

            _context.Competitors.Remove(competitor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
