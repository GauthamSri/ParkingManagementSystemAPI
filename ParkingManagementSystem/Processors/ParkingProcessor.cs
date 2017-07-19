using ParkingManagementSystem.DbRepository;
using ParkingManagementSystem.DbRepository.Interfaces;
using ParkingManagementSystem.Models;
using ParkingManagementSystem.Processors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ParkingManagementSystem.Processors
{
    public class ParkingProcessor : IParkingProcessor
    {
        IParkingRepo pRepo;
        ICarRepo cRepo;

        public ParkingProcessor(IParkingRepo _pRepo, ICarRepo _cRepo)
        {
            this.pRepo = _pRepo ?? new ParkingRepo(); //this would be resolved by using IoC container. For now, keeping it simple
            this.cRepo = _cRepo??  new CarRepo();
        }

        public bool ParkCar(int level, int spot, Car car)
        {
            if (isSpaceAvailable(level, spot))
            {

                var parkingSpace = pRepo.GetParkingSpaceByLevelAndSpot(level, spot);

                if (parkingSpace.ParkingType == car.ParkingType)
                {
                    car.Id = cRepo.AddCar(car);
                    pRepo.AddParkingInstance(car.Id, parkingSpace.Id);
                    return true;
                }
                else
                    return false;

            }
            else
            {
                return false;
            }


        }

        public string GetParkingSpace(string licensePlate)
        {
            StringBuilder parkingSpace = new StringBuilder();


            var pSpace = pRepo.GetParkingSpaceByCar(licensePlate);

            if (pSpace != null)
            {
                parkingSpace.Append(" Level - ");
                parkingSpace.Append(pSpace.Level);
                parkingSpace.Append(" Space - ");
                parkingSpace.Append(pSpace.Spot);

                return parkingSpace.ToString();
            }


            return string.Empty;
        }

        public string GetParkingSpaceByOwner(string ownerName)
        {
            StringBuilder parkingSpace = new StringBuilder();


            var pSpace = pRepo.GetParkingSpaceByOwner(ownerName);

            if (pSpace != null)
            {
                parkingSpace.Append(" Level - ");
                parkingSpace.Append(pSpace.Level);
                parkingSpace.Append(" Space - ");
                parkingSpace.Append(pSpace.Spot);

                return parkingSpace.ToString();
            }


            return string.Empty;
        }

        public String GetOwner(int level, int spot)
        {

           var car = cRepo.GetParkedCarBySpace(level, spot);
           return (car != null ? car.OwnerName : String.Empty);
        }

        public bool RemoveCar(int level, int spot)
        {
            var pInstance = pRepo.GetParkingInstanceBySpace(level, spot);
            var car = cRepo.GetCarById(pInstance.CarId);

            return (pRepo.DeleteParkingInstanceBySpace(pInstance.Id) && cRepo.DeleteCar(car.Id));
        }


        private bool isSpaceAvailable(int level, int spot)
        {
            return (pRepo.GetParkingInstanceBySpace(level, spot) == null);
        }
    }
}