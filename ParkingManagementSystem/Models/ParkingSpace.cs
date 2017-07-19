using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingManagementSystem.Models
{
    public class ParkingSpace
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int Spot { get; set; }
        public int ParkingType { get; set; }
    }
}