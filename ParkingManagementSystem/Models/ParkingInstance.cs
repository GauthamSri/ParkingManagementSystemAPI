using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingManagementSystem.Models
{
    public class ParkingInstance
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int ParkingSpaceId { get; set; }
        public DateTime StartTime { get; set; }
    }
}