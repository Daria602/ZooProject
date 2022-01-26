using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.DAL.Entities;
using ZooProject.DAL.Models;

namespace ZooProject.BLL.Interfaces
{
    public interface IZookeeperManager
    {
        Task CreateNewZookeeper(Zookeeper zookeeper);
        Task UpdateZookeeper(Zookeeper zookeeper);
        
        Task DeleteZookeeper(int id);
        Task<List<ZookeeperModel>> GetZookeepers();
        Task<ZookeeperModel> GetZookeeperById(int id);
    }
}
