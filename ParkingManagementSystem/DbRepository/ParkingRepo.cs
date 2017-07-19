using ParkingManagementSystem.DbRepository.Interfaces;
using ParkingManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingManagementSystem.DbRepository
{
    public class ParkingRepo : IParkingRepo
    {
        public ParkingSpace GetParkingSpaceById(int id)
        {
            using (ParkingSystemContext Ctx = new ParkingSystemContext())
            {
                return Ctx.ParkingSpaces.Where(t => t.Id == id).Select(t => t).FirstOrDefault();
            }
        }

        public ParkingSpace GetParkingSpaceByLevelAndSpot(int level, int spot)
        {
            using (ParkingSystemContext Ctx = new ParkingSystemContext())
            {
                return Ctx.ParkingSpaces.Where(t => t.Level == level && t.Spot == spot).Select(t => t).FirstOrDefault();
            }
        }

        public ParkingSpace GetParkingSpaceByCar(string LicensePlate)
        {
            using (ParkingSystemContext Ctx = new ParkingSystemContext())
            {
                return (from car in Ctx.Cars
                        join pi in Ctx.ParkingInstances on car.Id equals pi.CarId
                        join ps in Ctx.ParkingSpaces on pi.ParkingSpaceId equals ps.Id
                        where car.LicensePlate.Equals(LicensePlate)
                        select ps).FirstOrDefault();

            }
        }

        public ParkingSpace GetParkingSpaceByOwner(string ownerName)
        {
            using (ParkingSystemContext Ctx = new ParkingSystemContext())
            {
                return (from car in Ctx.Cars
                        join pi in Ctx.ParkingInstances on car.Id equals pi.CarId
                        join ps in Ctx.ParkingSpaces on pi.ParkingSpaceId equals ps.Id
                        where car.OwnerName.Equals(ownerName)
                        select ps).FirstOrDefault();

            }
        }

        public int AddParkingSpace(ParkingSpace pSpace)
        {
            using (ParkingSystemContext Ctx = new ParkingSystemContext())
            {
                Ctx.ParkingSpaces.Add(pSpace);
                Ctx.SaveChanges();

            }

            return pSpace.Id;
        }

        public int AddParkingInstance(int carId, int spaceId)
        {
            using (ParkingSystemContext Ctx = new ParkingSystemContext())
            {
                ParkingInstance pInstance = new ParkingInstance();
                pInstance.CarId = carId;
                pInstance.ParkingSpaceId = spaceId;
                pInstance.StartTime = DateTime.UtcNow;

                Ctx.ParkingInstances.Add(pInstance);
                Ctx.SaveChanges();
                return pInstance.Id;

            }

            
        }

        public ParkingInstance GetParkingInstanceById(int id)
        {
            using (ParkingSystemContext Ctx = new ParkingSystemContext())
            {
                return Ctx.ParkingInstances.Where(t => t.Id == id).Select(t => t).FirstOrDefault();
            }
        }

        public ParkingInstance GetParkingInstanceByCar(string LicensePlate)
        {
            using (ParkingSystemContext Ctx = new ParkingSystemContext())
            {
                return (from car in Ctx.Cars
                         join pi in Ctx.ParkingInstances on car.Id equals pi.CarId
                         where car.LicensePlate.Equals(LicensePlate)
                         select pi).FirstOrDefault();

            }
        }

        public ParkingInstance GetParkingInstanceBySpace(int level, int spot)
        {
            using (ParkingSystemContext Ctx = new ParkingSystemContext())
            {
                return (from ps in Ctx.ParkingSpaces
                        join pi in Ctx.ParkingInstances on ps.Id equals pi.ParkingSpaceId
                        where ps.Level == level && ps.Spot == spot 
                        select pi).FirstOrDefault();

            }
        }

        public bool DeleteParkingInstanceBySpace(int pInstanceId)
        {
            try
            {
                using (ParkingSystemContext Ctx = new ParkingSystemContext())
                {
                    var pInstance = Ctx.ParkingInstances.Where(t => t.Id == pInstanceId).Select(t => t).FirstOrDefault();
                    if (pInstance != null)
                    {
                        Ctx.ParkingInstances.Remove(pInstance);
                        Ctx.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                    

                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        
    }
}