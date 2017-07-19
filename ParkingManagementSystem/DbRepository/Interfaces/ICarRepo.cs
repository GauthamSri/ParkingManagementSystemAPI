using ParkingManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagementSystem.DbRepository.Interfaces
{
    public interface ICarRepo
    {
        Car GetCarById(int id);
        Car GetCarByPlate(string LicensePlate);
        Car GetParkedCarBySpace(int level, int spot);
        int AddCar(Car car);
        bool DeleteCar(int carId);
       
    }
}
