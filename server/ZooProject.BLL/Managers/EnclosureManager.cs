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
    public class EnclosureManager : IEnclosureManager
    {
        private readonly IEnclosureRepository _enclosureRepository;
        public EnclosureManager(IEnclosureRepository encRepo)
        {
            _enclosureRepository = encRepo;
        }
        public async Task CreateNewEnclosure(Enclosure enclosure)
        {
            await _enclosureRepository.Create(enclosure);
        }

        public async Task DeleteEnclosure(int id)
        {
            await _enclosureRepository.Delete(id);
        }

        public async Task<EnclosureModel> GetEnclosureById(int id)
        {
            var enclosures = await _enclosureRepository.GetById(id);

            return enclosures;
        }

        public async Task<List<EnclosureModel>> GetEnclosures()
        {
            var enclosures = await _enclosureRepository.GetAll();

            return enclosures;
        }

        public async Task UpdateEnclosure(Enclosure enclosure)
        {
            await _enclosureRepository.Update(enclosure);
        }
    }
}
