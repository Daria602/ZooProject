using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooProject.BLL.Interfaces;
using ZooProject.DAL.Entities;

namespace ZooProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnclosureV2Controller : ControllerBase
    {
        private readonly IEnclosureManager _enclosureManager;

        public EnclosureV2Controller(IEnclosureManager enclosureManager)
        {
            _enclosureManager = enclosureManager;
        }
        [HttpPost("CreateNewEnclosure")]

        public async Task<IActionResult> CreateNewEnclosure([FromBody] Enclosure enclosure)
        {
            
            await _enclosureManager.CreateNewEnclosure(enclosure);
            return Ok("All went good");
        }

        [HttpPut("UpdateEnclosure")]
        public async Task<IActionResult> UpdateEnclosure([FromBody] Enclosure enclosure)
        {
            await _enclosureManager.UpdateEnclosure(enclosure);
            return Ok();
        }

        [HttpDelete("DeleteEnclosure/{id}")]

        public async Task<IActionResult> DeleteEnclosure([FromRoute] int id)
        {
            await _enclosureManager.DeleteEnclosure(id);
            return Ok();
        }

        [HttpGet("GetAllEnclosures")]
        public async Task<IActionResult> GetAllEnclosures()
        {
            var strings = await _enclosureManager.GetEnclosures();

            return Ok(strings);
        }

        [HttpGet("GetSpecificEnclosure/{id}")]
        public async Task<IActionResult> GetSpecificEnclosure([FromRoute] int id)
        {
            var strings = await _enclosureManager.GetEnclosureById(id);

            return Ok(strings);
        }
    }
}
