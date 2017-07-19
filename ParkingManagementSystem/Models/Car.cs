using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingManagementSystem.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string OwnerName { get; set; }
        public int ParkingType { get; set; }
    }
}