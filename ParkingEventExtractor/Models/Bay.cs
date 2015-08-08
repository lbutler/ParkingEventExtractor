using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingEventExtractor.Models
{
    public class Bay
    {
        public Int64 BayId { get; set; }
        public string StreetMarker { get; set; }
        public Int64 AreaId { get; set; }

        //[Key, Column(Order = 1), ForeignKey("Street")]
        public Int64 StreetId { get; set; }
        //[Key, Column(Order = 2), ForeignKey("BetweenStreet1")]
        //public Int64 BetweenStreet1Id { get; set; }
        //[Key, Column(Order = 3), ForeignKey("BetweenStreet2")]
        //public Int64 BetweenStreet2Id { get; set; }

        public Int64 SideId { get; set; }


        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public virtual Street Street { get; set; }
        //public virtual Street BetweenStreet1 { get; set; }
        //public virtual Street BetweenStreet2 { get; set; }

        public List<ParkingEvent> ParkingEvents { get; set; }

        

    }
}
