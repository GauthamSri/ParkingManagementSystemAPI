using ParkingManagementSystem.DbRepository;
using ParkingManagementSystem.DbRepository.Interfaces;
using ParkingManagementSystem.Models;
using ParkingManagementSystem.Processors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingManagementSystem.Processors
{
    public class PaymentProcessor : IPaymentProcessor
    {

        IParkingRepo pRepo;
        ICarRepo cRepo;

        public PaymentProcessor(IParkingRepo _pRepo, ICarRepo _cRepo)
        {
            this.pRepo = _pRepo ?? new ParkingRepo(); //this would be resolved by using IoC container. For now, keeping it simple
            this.cRepo = _cRepo ?? new CarRepo();
        }

        public double GetParkingCostForSpace(int level, int spot, DateTime endTime)
        {
            var parkedCarInstance = pRepo.GetParkingInstanceBySpace(level, spot);
            var parkingSpace = pRepo.GetParkingSpaceById(parkedCarInstance.ParkingSpaceId);

            var noOfHoursParked = (endTime - parkedCarInstance.StartTime).Hours;

            noOfHoursParked = (noOfHoursParked == 0) ? 1 : noOfHoursParked;

            return noOfHoursParked * GetCostForParkingType((ParkingTypes)parkingSpace.ParkingType);

        }

        public double GetParkingCostForCar(string LicensePlate, DateTime endTime)
        {
            var parkedCarInstance = pRepo.GetParkingInstanceByCar(LicensePlate);
            var parkedCar = cRepo.GetCarById(parkedCarInstance.CarId);

            var noOfHoursParked = (endTime - parkedCarInstance.StartTime).Hours;

            return noOfHoursParked * GetCostForParkingType((ParkingTypes)parkedCar.ParkingType);

        }

        private double GetCostForParkingType(ParkingTypes type)
        {
            return Convert.ToDouble((ParkingTypeHourlyRate)type);
        }
    }
}