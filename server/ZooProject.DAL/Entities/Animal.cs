using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooProject.DAL.Entities
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearBorn { get; set; }
        public int AverageLongevity { get; set; }
        public string Gender { get; set; }
        public virtual Enclosure Enclosure { get; set; }
        public virtual ICollection<Diet> Diet { get; set; }
        public virtual ICollection<AnimalZookeeper> AnimalZookeepers { get; set; }

    }
}
