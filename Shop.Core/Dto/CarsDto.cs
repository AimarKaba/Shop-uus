using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Shop.Core.Dtos
{
    public class CarsDto
    {
        public Guid? Id { get; set; }
        public string Mark { get; set; }
        public string Series { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }


        public List<IFormFile> Files { get; set; }
        public IEnumerable<ExistingFilePathDto> ExistingFilePaths { get; set; }
            = new List<ExistingFilePathDto>();
    }
}
