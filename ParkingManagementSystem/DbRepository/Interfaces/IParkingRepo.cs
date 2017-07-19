using ParkingManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagementSystem.DbRepository.Interfaces
{
    public interface IParkingRepo
    {
       ParkingSpace GetParkingSpaceById(int id);       
       ParkingSpace GetParkingSpaceByLevelAndSpot(int level, int spot);      
       ParkingSpace GetParkingSpaceByCar(string LicensePlate);
       ParkingSpace GetParkingSpaceByOwner(string ownerName);
       int AddParkingSpace(ParkingSpace pSpace);
       int AddParkingInstance(int carId, int spaceId);
       ParkingInstance GetParkingInstanceById(int id);        
       ParkingInstance GetParkingInstanceByCar(string LicensePlate);
       ParkingInstance GetParkingInstanceBySpace(int level, int spot);
       bool DeleteParkingInstanceBySpace(int pInstanceId);
        
    }
}
