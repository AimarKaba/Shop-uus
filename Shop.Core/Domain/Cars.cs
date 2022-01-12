using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain
{
    public class Cars
    {
        public Guid? Id { get; set; }
        public string Mark { get; set; }
        public string Series { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public IEnumerable<ExistingFilePath> ExistingFilePaths { get; set; }
    = new List<ExistingFilePath>();
    }
}
