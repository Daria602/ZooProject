using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.DAL.Entities;
using ZooProject.DAL.Models;

namespace ZooProject.BLL.Interfaces
{
    public interface IAnimalManager
    {
        Task CreateNewAnimal(Animal animal);
        Task UpdateAnimal(Animal animal);
        //int id, string name, int yearborn, int averagelongevity
        Task DeleteAnimal(int id);
        Task<List<AnimalModel>> GetAnimals();
        Task<AnimalModel> GetAnimalById(int id);
        Task<List<AnimalModel>> GetAnimalsByYear(int year);
        Task<List<Tuple<ZookeeperModel, int>>> GetAnimalsZookeepers();
        Task<List<Tuple<AnimalModel, DietModel>>> GetAnimalsAndDiets();
    }
}
