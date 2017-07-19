namespace ParkingManagementSystem.Migrations
{
    using ParkingManagementSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ParkingManagementSystem.DbRepository.ParkingSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ParkingManagementSystem.DbRepository.ParkingSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            context.ParkingSpaces.AddOrUpdate(x => new { x.Level, x.Spot },

                new ParkingSpace() { Level = 1, Spot = 1, ParkingType = (int)ParkingTypes.FrequentFlyer },
                new ParkingSpace() { Level = 1, Spot = 2, ParkingType = (int)ParkingTypes.FrequentFlyer },
                new ParkingSpace() { Level = 1, Spot = 3, ParkingType = (int)ParkingTypes.FrequentFlyer },
                new ParkingSpace() { Level = 1, Spot = 4, ParkingType = (int)ParkingTypes.FrequentFlyer },
                new ParkingSpace() { Level = 1, Spot = 5, ParkingType = (int)ParkingTypes.FrequentFlyer },
                new ParkingSpace() { Level = 1, Spot = 6, ParkingType = (int)ParkingTypes.FrequentFlyer },
                new ParkingSpace() { Level = 1, Spot = 7, ParkingType = (int)ParkingTypes.Valet },
                new ParkingSpace() { Level = 1, Spot = 8, ParkingType = (int)ParkingTypes.Valet },


                new ParkingSpace() { Level = 2, Spot = 1, ParkingType = (int)ParkingTypes.Valet },
                new ParkingSpace() { Level = 2, Spot = 2, ParkingType = (int)ParkingTypes.Valet },
                new ParkingSpace() { Level = 2, Spot = 3, ParkingType = (int)ParkingTypes.Valet },
                new ParkingSpace() { Level = 2, Spot = 4, ParkingType = (int)ParkingTypes.Valet },
                new ParkingSpace() { Level = 2, Spot = 5, ParkingType = (int)ParkingTypes.Valet },
                new ParkingSpace() { Level = 2, Spot = 6, ParkingType = (int)ParkingTypes.General },
                new ParkingSpace() { Level = 2, Spot = 7, ParkingType = (int)ParkingTypes.General },
                new ParkingSpace() { Level = 2, Spot = 8, ParkingType = (int)ParkingTypes.General },

                new ParkingSpace() { Level = 3, Spot = 1, ParkingType = (int)ParkingTypes.General },
                new ParkingSpace() { Level = 3, Spot = 2, ParkingType = (int)ParkingTypes.General },
                new ParkingSpace() { Level = 3, Spot = 3, ParkingType = (int)ParkingTypes.General },
                new ParkingSpace() { Level = 3, Spot = 4, ParkingType = (int)ParkingTypes.General },
                new ParkingSpace() { Level = 3, Spot = 5, ParkingType = (int)ParkingTypes.General },
                new ParkingSpace() { Level = 3, Spot = 6, ParkingType = (int)ParkingTypes.General },
                new ParkingSpace() { Level = 3, Spot = 7, ParkingType = (int)ParkingTypes.General },
                new ParkingSpace() { Level = 3, Spot = 8, ParkingType = (int)ParkingTypes.General }


                );
        }
    }
}
