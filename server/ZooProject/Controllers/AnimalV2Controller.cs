using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooProject.BLL.Interfaces;
using ZooProject.Constants;
using ZooProject.DAL.Entities;
using ZooProject.DAL.Interfaces;

namespace ZooProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalV2Controller : ControllerBase
    {
        private readonly IAnimalManager _animalManager;

        public AnimalV2Controller(IAnimalManager animalManager)
        {
            _animalManager = animalManager;
        }

        [HttpPost("CreateNewAnimal")]
        [Authorize(Roles = UserRoleTypes.Admin)]

        public async Task<IActionResult> CreateNewAnimal([FromBody] Animal animal)
        {
            if (string.IsNullOrEmpty(animal.Gender))
            {
                return BadRequest("Gender is required!");
            }
            if (animal.YearBorn == 0 || animal.AverageLongevity == 0)
            {
                return BadRequest("Year and longevity are required!");
            }
            await _animalManager.CreateNewAnimal(animal);
            return Ok(new { message = "All went good" });
        }

        [HttpPut("UpdateAnimal")]
        public async Task<IActionResult> UpdateAnimal([FromBody] Animal animal)
        {
            await _animalManager.UpdateAnimal(animal);
            return Ok();
        }

        [HttpDelete("DeleteAnimal/{id}")]

        public async Task<IActionResult> DeleteAnimal([FromRoute] int id)
        {
            await _animalManager.DeleteAnimal(id);
            return Ok();
        }

        [HttpGet("GetAllAnimals")]
        
        public async Task<IActionResult> GetAllAnimals()
        {
            var strings = await _animalManager.GetAnimals();
            
            return Ok(strings);
        }

        [HttpGet("GetSpecificAnimal/{id}")]
        public async Task<IActionResult> GetSpecificAnimal([FromRoute] int id)
        {
            var strings = await _animalManager.GetAnimalById(id);

            return Ok(strings);
        }

        [HttpGet("GetAnimalsWhereYear/{year}")]

        public async Task<IActionResult> GetAnimalsWhereYear([FromRoute] int year)
        {
            var strings = await _animalManager.GetAnimalsByYear(year);
            
            return Ok(strings);
        }
        
     
        
        [HttpGet("GetNrAnimalsByZookeeper")]

        public async Task<IActionResult> GetNrAnimalsByZookeeper()
        {
            var strings = await _animalManager.GetAnimalsZookeepers();
            return Ok(strings);

        }
        

        [HttpGet("GetAnimalsNamesAndDiets")]

        public async Task<IActionResult> GetAnimalsNamesAndDiets()
        {
            var strings = await _animalManager.GetAnimalsAndDiets();
            return Ok(strings);

        }
        
    }
}
