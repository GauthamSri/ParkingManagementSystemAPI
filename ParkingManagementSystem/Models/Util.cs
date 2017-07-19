using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingManagementSystem.Models
{

    enum ParkingTypes
    {
        General = 1,
        Valet = 2,
        FrequentFlyer = 3
    }

    // in realtime, this will be either in mapping table or app.config file
    enum ParkingTypeHourlyRate
    {
        General = 10,
        Valet = 20,
        FrequentFlyer = 30
    }

    public class Util
    {
    }
}