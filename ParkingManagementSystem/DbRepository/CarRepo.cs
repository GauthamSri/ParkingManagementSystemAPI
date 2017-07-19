using ParkingManagementSystem.DbRepository.Interfaces;
using ParkingManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingManagementSystem.DbRepository
{
    public class CarRepo : ICarRepo
    {
        public Car GetCarById(int id)
        {
            using(ParkingSystemContext Ctx = new ParkingSystemContext())
            {
                return Ctx.Cars.Where(t => t.Id == id).Select(t => t).FirstOrDefault();
            }
        }

        public Car GetCarByPlate(string LicensePlate)
        {
            using (ParkingSystemContext Ctx = new ParkingSystemContext())
            {
                return Ctx.Cars.Where(t => t.LicensePlate.Equals(LicensePlate)).Select(t => t).FirstOrDefault();
            }
        }

        public Car GetParkedCarBySpace(int level, int spot)
        {
            using (ParkingSystemContext Ctx = new ParkingSystemContext())
            {
                return (from ps in Ctx.ParkingSpaces
                        join pi in Ctx.ParkingInstances on ps.Id equals pi.ParkingSpaceId
                        join car in Ctx.Cars on pi.CarId equals car.Id
                        where ps.Level == level && ps.Spot == spot
                        select car).FirstOrDefault();

            }
        }

        public int AddCar(Car car)
        {
            using (ParkingSystemContext Ctx = new ParkingSystemContext())
            {
               Ctx.Cars.Add(car);
               Ctx.SaveChanges();

            }

            return car.Id;
        }

        public bool DeleteCar(int carId)
        {
            try
            {
                using (ParkingSystemContext Ctx = new ParkingSystemContext())
                {
                    var car = Ctx.Cars.Where(t => t.Id == carId).Select(t => t).FirstOrDefault();                 

                    if (car != null)
                    {
                        Ctx.Cars.Remove(car);
                        Ctx.SaveChanges();
                        return true;
                    }
                    else
                        return false;

                }
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}