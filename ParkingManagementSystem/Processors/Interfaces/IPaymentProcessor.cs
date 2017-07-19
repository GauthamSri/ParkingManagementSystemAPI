using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagementSystem.Processors.Interfaces
{
    public interface IPaymentProcessor
    {
        double GetParkingCostForSpace(int level, int spot, DateTime endTime);
        double GetParkingCostForCar(string LicensePlate, DateTime endTime);

    }
}
