using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class AnimalsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AnimalsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddAnimal")]
        public async Task<IActionResult> AddAnimal([FromBody] Animal animal)
        {
            if (string.IsNullOrEmpty(animal.Gender))
            {
                return BadRequest("Gender is required!");
            }
            if (animal.YearBorn == 0 || animal.AverageLongevity == 0)
            {
                return BadRequest("Year and longevity are required!");
            }

            await _context.Animals.AddAsync(animal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("GetAnimals")]

        public async Task<IActionResult> GetAnimals()
        {
            var animals = await _context.Animals.ToListAsync();
            return Ok(animals);
        }

        [HttpGet("GetAnimalsNamesAndYears")]

        public async Task<IActionResult> GetAnimalsNamesAndYears()
        {
            var animals = await _context.Animals.Select(x => new { x.Name, x.YearBorn }).ToListAsync();
            return Ok(animals);
        }

        [HttpGet("GetAnimalsWhereYear/{year}")]

        public async Task<IActionResult> GetAnimalsWhereYear([FromRoute] int year)
        {
            var animals = await _context.Animals
                                        .Where(x => x.YearBorn == year)
                                        .Select(x => new { x.Name, x.YearBorn })
                                        .ToListAsync();
            return Ok(animals);
        }

        [HttpGet("GetAnimalsDiets")]

        public async Task<IActionResult> GetAnimalsDiets()
        {
            try
            {
                var animalsWithDiets = await _context
                .Animals
                .Include(x => x.Diet)
                .Where(x => x.Diet.FirstOrDefault().AnimalId != null)
                .Select(x => new { AnimalId = x.Id, DietId = x.Diet.FirstOrDefault().Id, DietType = x.Diet.FirstOrDefault().FoodType })
                .ToListAsync();
                return Ok(animalsWithDiets);
            }
            catch (Exception exc)
            {
                return BadRequest();
            }
            
        }

        [HttpGet("GetAnimalsCombinedDiets")]

        public async Task<IActionResult> GetAnimalsCombinedDiets()
        {
            var animalsDiets = await _context
                .Animals
                .Include(x => x.Diet)
                .Where(x => x.Diet.FirstOrDefault().AnimalId != null)
                .Where(x => x.Diet.Count > 1)
                .ToListAsync();
            return Ok(animalsDiets);

        }

        [HttpGet("GetAnimalsOrderByName")]

        public async Task<IActionResult> GetAnimalsOrderByName()
        {
            var animals = await _context
                .Animals
                .OrderBy(x => x.Name)
                //.OrderByDescending(x => x.Name)
                .ToListAsync();
            return Ok(animals);

        }

        [HttpGet("GetNrAnimalsByZookeeper")]

        public async Task<IActionResult> GetNrAnimalsByZookeeper()
        {
            try
            {
                var animalsZookeepers =  _context
                    .AnimalZookeepers
                    .Include(x => x.Animal)
                    .Include(x => x.Zookeeper)
                    .GroupBy(x => new { x.ZookeeperId, x.Zookeeper.Name })
                    .Select(x => new
                    {
                        Zookeeper = x.Key, AnimalsNr = x.Count()
                    });
                return Ok(animalsZookeepers);
                    
                    
            }
            catch (Exception exc)
            {
                return BadRequest();
            }
            
        }

        [HttpGet("GetAnimalsNamesAndDiet")]

        public async Task<IActionResult> GetAnimalsNamesAndDiet()
        {
            try
            {
                var animals = _context.Animals;
                var join = _context.Diets.Join(animals, x => x.AnimalId, y => y.Id, (x,y) => new
                {
                    AnimalName = y.Name,
                    Meals = x.FoodType
                });
                return Ok(join);
            }
            catch (Exception exc)
            {
                return BadRequest();
            }
        }

    }
}
