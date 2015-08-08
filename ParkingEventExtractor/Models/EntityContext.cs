using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace ParkingEventExtractor.Models
{
    public class EntityContext : DbContext
    {
        public DbSet<ParkingEvent> ParkingEvents { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Side> Sides { get; set; }
        public DbSet<SignPlate> SignPlates { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Bay> Bays { get; set; }


    }
}
