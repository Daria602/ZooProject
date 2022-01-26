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
    public class ZookeeperManager : IZookeeperManager
    {
        private readonly IZookeeperRepository _zookeeperRepository;
        public ZookeeperManager(IZookeeperRepository zooRepo)
        {
            _zookeeperRepository = zooRepo;
        }
        public async Task CreateNewZookeeper(Zookeeper zookeeper)
        {
            await _zookeeperRepository.Create(zookeeper);
        }

        public async Task DeleteZookeeper(int id)
        {
            await _zookeeperRepository.Delete(id);
        }

        public async Task<ZookeeperModel> GetZookeeperById(int id)
        {
            var zookeepers = await _zookeeperRepository.GetById(id);

            return zookeepers;
        }

        public async Task<List<ZookeeperModel>> GetZookeepers()
        {
            var zookeepers = await _zookeeperRepository.GetAll();

            return zookeepers;
        }

        public async Task UpdateZookeeper(Zookeeper zookeeper)
        {
            await _zookeeperRepository.Update(zookeeper);
        }
    }
}
