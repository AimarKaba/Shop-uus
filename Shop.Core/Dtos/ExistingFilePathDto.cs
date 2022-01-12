using System;


namespace Shop.Core.Dtos
{
    public class ExistingFilePathDto
    {
        public Guid Id { get; set; }
        public string ExistingFilePath { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? CarId { get; set; }
    }
}
