using ParkingManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagementSystem.Processors.Interfaces
{
    public interface IParkingProcessor
    {
       bool ParkCar(int level, int spot, Car car);
       string GetParkingSpace(string licensePlate);
       string GetParkingSpaceByOwner(string ownerName);
       String GetOwner(int level, int spot);
       bool RemoveCar(int level, int spot);

    }
}
