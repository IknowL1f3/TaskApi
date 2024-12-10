using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApi.BDLvl;
using TestApi.Entities;
using TestApi.Models;
using TestApi.Validator;

namespace TestApi.BLL
{
    public class ParkingEventBLL
    {
        private ParkingEventRepository _repository = new ParkingEventRepository();
        private ParkingEventValidator _validator = new ParkingEventValidator();

        public List<ResponseParkingEvent> GetAllParkingEvents()
        {
            return _repository.GetAllParkingEvents().ConvertAll(p => new ResponseParkingEvent(p));
        }

        public ParkingEvent GetParkingEvent(int id)
        {
            return _repository.GetParkingEventById(id);
        }

        public List<ParkingEvent> GetParkingEventByUserId(int userId)
        {
            var parkingEvents = _repository.GetParkingEventsByUserId(userId);
            parkingEvents.Reverse();  
            return parkingEvents;
        }

        public void AddParkingEvent(ParkingEvent parkingEvent)
        {
            if (parkingEvent == null)
                return;

            ValidationResult result = _validator.Validate(parkingEvent);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            _repository.AddParkingEvent(parkingEvent);
        }

        public void UpdateParkingEvent(ParkingEvent parkingEvent)
        {
            if (parkingEvent == null)
                return;

            ValidationResult result = _validator.Validate(parkingEvent);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            _repository.UpdateParkingEvent(parkingEvent);
        }

        public void RemoveParkingEvent(int id)
        {
            _repository.RemoveParkingEvent(id);
        }
    }
}