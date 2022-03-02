using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.Core.Domain
{
    public class Spaceship
    {
        [Key]
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
