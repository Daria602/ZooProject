using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ZooProject.DAL.Entities
{
    public class AnimalZookeeper
    {
        public int Id { get; set; }
        public int? AnimalId { get; set; }
        public int ZookeeperId { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual Zookeeper Zookeeper { get; set; }
    }
}
