using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.BLL.Interfaces;
using ZooProject.DAL.Entities;
using ZooProject.DAL.Interfaces;
using ZooProject.DAL.Models;

namespace ZooProject.BLL.Managers
{
    public class AnimalManager : IAnimalManager
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalManager(IAnimalRepository anRepo)
        {
            _animalRepository = anRepo;
        }
        public async Task<List<AnimalModel>> GetAnimals()
        {
            var animals = await _animalRepository.GetAll();
            
            return animals;
        }

        public async Task<AnimalModel> GetAnimalById(int id)
        {
            var animal = await _animalRepository.GetById(id);

            return animal;
        }

        public async Task<List<AnimalModel>> GetAnimalsByYear(int year)
        {
            var animals = await _animalRepository.GetByYear(year);
            return animals;
        }

        public async Task<List<Tuple<ZookeeperModel, int>>> GetAnimalsZookeepers()
        {
            var animalsZookeepers = await _animalRepository.GetNrByZookeepers();
            return animalsZookeepers;
        }

        public async Task<List<Tuple<AnimalModel, DietModel>>> GetAnimalsAndDiets()
        {
            var animalsDiets = await _animalRepository.GetAnimalsDiets();
            return animalsDiets;
        }

        public async Task CreateNewAnimal(Animal animal)
        {
            await _animalRepository.Create(animal);
        }

        public async Task UpdateAnimal(Animal animal)
        {
            await _animalRepository.Update(animal);
        }

        public async Task DeleteAnimal(int id)
        {
            await _animalRepository.Delete(id);
        }
    }
}
