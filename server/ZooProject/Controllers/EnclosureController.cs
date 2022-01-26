using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooProject.DAL;
using ZooProject.DAL.Entities;

namespace ZooProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnclosureController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnclosureController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddEnclosure")]
        public async Task<IActionResult> AddEnclosure([FromBody] Enclosure enclosure)
        {
            if (string.IsNullOrEmpty(enclosure.EnclosureType))
            {
                return BadRequest("Enclosure type is required!");
            }

            await _context.Enclosures.AddAsync(enclosure);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("UpdateEnclosures")]

        public async Task<IActionResult> UpdateEnclosures([FromQuery] int id, string encType, int sizem2)
        {
            var enclosure = await _context.Enclosures.FindAsync(id);

            enclosure.EnclosureType = encType;
            enclosure.SizeM2 = sizem2;
            await _context.SaveChangesAsync();

            return Ok("Success!");

        }

        
    }
}
