using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain
{
    public class ExistingFilePath
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? CarId { get; set; }
    }
}
