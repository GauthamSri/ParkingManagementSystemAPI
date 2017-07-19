using ParkingManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ParkingManagementSystem.DbRepository
{
    public class ParkingSystemContext : DbContext
    {
        public ParkingSystemContext()
            : base("name = DefaultConnection")
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<ParkingSpace> ParkingSpaces { get; set; }
        public DbSet<ParkingInstance> ParkingInstances { get; set; }
    }
}