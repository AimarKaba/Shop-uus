using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models.Spaceship
{
    public class SpaceshipListViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Company { get; set; }
        public int EnginePower { get; set; }
        public string Country { get; set; }
        public DateTime LaunchDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
