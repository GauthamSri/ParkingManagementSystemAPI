using ParkingManagementSystem.DbRepository;
using ParkingManagementSystem.DbRepository.Interfaces;
using ParkingManagementSystem.Models;
using ParkingManagementSystem.Processors;
using ParkingManagementSystem.Processors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParkingManagementSystem.Controllers
{
    public class ParkingController : ApiController
    {
        IParkingProcessor parkingProcessor;
        IPaymentProcessor paymentProcessor;

         public ParkingController()
        {
            parkingProcessor = new ParkingProcessor(new ParkingRepo(), new CarRepo());
            paymentProcessor = new PaymentProcessor(new ParkingRepo(), new CarRepo());
        }

         public ParkingController(IParkingProcessor _pProcessor, IPaymentProcessor _payProcessor,IParkingRepo _pRepo, ICarRepo _cRepo)
        {
            parkingProcessor = _pProcessor ?? ( new ParkingProcessor(_pRepo ?? new ParkingRepo(), _cRepo ?? new CarRepo()) );
            paymentProcessor = _payProcessor ?? (new PaymentProcessor(_pRepo ?? new ParkingRepo(), _cRepo ?? new CarRepo()) );
        }


        [HttpPost]
         public HttpResponseMessage AddCar([FromBody]Car car, int level, int spot)
        {
            try
            {
                 return Request.CreateResponse(HttpStatusCode.OK, (parkingProcessor.ParkCar(level, spot, car)));
            }
            catch (Exception ex)
            {
                //log the exception
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Some Error Happened.");
            }

        }

        [HttpPost]
        public HttpResponseMessage Remove(int level, int spot)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, (parkingProcessor.RemoveCar(level, spot)));
            }
            catch (Exception ex)
            {
                //log the exception
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Some Error Happened.");
            }

        }


        [HttpGet]
        public HttpResponseMessage GetParkingCost(int level, int spot)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, (paymentProcessor.GetParkingCostForSpace(level, spot, DateTime.UtcNow)));
            }
            catch (Exception ex)
            {
                //log the exception
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Some Error Happened.");
            }

        }

        [HttpGet]
        public HttpResponseMessage GetOwner(int level, int spot)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, (parkingProcessor.GetOwner(level, spot)));
            }
            catch (Exception ex)
            {
                //log the exception
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Some Error Happened.");
            }

        }

        [HttpGet]
        public HttpResponseMessage GetParkingSpaceByLicense(string licensePlate)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, (parkingProcessor.GetParkingSpace(licensePlate)));
            }
            catch (Exception ex)
            {
                //log the exception
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Some Error Happened.");
            }

        }

        [HttpGet]
        public HttpResponseMessage GetParkingSpaceByOwner(string ownerName)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, (parkingProcessor.GetParkingSpaceByOwner(ownerName)));
            }
            catch (Exception ex)
            {
                //log the exception
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Some Error Happened.");
            }

        }

    }
}
