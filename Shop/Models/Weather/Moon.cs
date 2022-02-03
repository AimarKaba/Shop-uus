using System;

namespace Shop.Models.Weather
{
    public class Moon
    {
        public string Rise { get; set; }
        public Int64 EpochRise { get; set; }
        public string Set { get; set; }
        public Int64 EpochSet { get; set; }
        public string Phase { get; set; }
        public Int32 Age { get; set; }
    }
}