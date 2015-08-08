using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingEventExtractor.Models
{
    public class SignPlate
    {
        public Int64 SignPlateId { get; set; }
        public string Sign { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int MinutesAllowed { get; set; }

    }
}
