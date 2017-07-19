using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingManagementSystem;
using ParkingManagementSystem.Controllers;
using Moq;
using ParkingManagementSystem.DbRepository.Interfaces;
using ParkingManagementSystem.Models;
using ParkingManagementSystem.Processors;

namespace ParkingManagementSystem.Tests.Controllers
{
    [TestClass]
    public class ParkingControllerTest
    {
        Mock<IParkingRepo> mockParkingRepo;
        Mock<ICarRepo> mockCarRepo;

        public ParkingControllerTest()
        {
            mockParkingRepo = new Mock<IParkingRepo>();
            mockCarRepo = new Mock<ICarRepo>();
        }

        [TestMethod]
        public void GetParkingSpaceTest()
        {
            // Arrange
            string ownerName = "test";
            ParkingSpace space = new ParkingSpace() { Level = 1, Spot = 3, ParkingType = 2 };
            mockParkingRepo.Setup(t => t.GetParkingSpaceByOwner(ownerName)).Returns(() => space);

            // Act
            ParkingProcessor parkProcessor = new ParkingProcessor(mockParkingRepo.Object, mockCarRepo.Object);
            var resultParkingSpace = parkProcessor.GetParkingSpaceByOwner(ownerName);

            // Assert
            Assert.IsNotNull(resultParkingSpace);
            Assert.AreEqual(false, String.IsNullOrEmpty(resultParkingSpace));
           
        }

       
    }
}
