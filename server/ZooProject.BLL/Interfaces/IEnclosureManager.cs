using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.DAL.Entities;
using ZooProject.DAL.Models;

namespace ZooProject.BLL.Interfaces
{
    public interface IEnclosureManager
    {
        Task CreateNewEnclosure(Enclosure enclosure);
        Task UpdateEnclosure(Enclosure enclosure);
        
        Task DeleteEnclosure(int id);
        Task<List<EnclosureModel>> GetEnclosures();
        Task<EnclosureModel> GetEnclosureById(int id);
    }
}
