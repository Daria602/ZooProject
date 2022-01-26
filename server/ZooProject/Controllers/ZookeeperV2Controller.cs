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
    public class ZookeeperV2Controller : ControllerBase
    {
        private readonly IZookeeperManager _zookeeperManager;

        public ZookeeperV2Controller(IZookeeperManager zookeeperManager)
        {
            _zookeeperManager = zookeeperManager;
        }
        [HttpPost("CreateNewZookeeper")]

        public async Task<IActionResult> CreateNewZookeeper([FromBody] Zookeeper zookeeper)
        {

            await _zookeeperManager.CreateNewZookeeper(zookeeper);
            return Ok(new { message = "All went good" });
        }

        [HttpPut("UpdateZookeeper")]
        public async Task<IActionResult> UpdateZookeeper([FromBody] Zookeeper zookeeper)
        {
            await _zookeeperManager.UpdateZookeeper(zookeeper);
            return Ok();
        }

        [HttpDelete("DeleteZookeeper/{id}")]

        public async Task<IActionResult> DeleteZookeeper([FromRoute] int id)
        {
            await _zookeeperManager.DeleteZookeeper(id);
            return Ok();
        }

        [HttpGet("GetAllZookeepers")]
        public async Task<IActionResult> GetAllZookeepers()
        {
            var strings = await _zookeeperManager.GetZookeepers();

            return Ok(strings);
        }

        [HttpGet("GetSpecificZookeeper/{id}")]
        public async Task<IActionResult> GetSpecificZookeeper([FromRoute] int id)
        {
            var strings = await _zookeeperManager.GetZookeeperById(id);

            return Ok(strings);
        }
    }
}
