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
    public class ParkingBLL
    {
        private ParkingRepository _repository = new ParkingRepository();
        private ParkingValidator _validator = new ParkingValidator();

        public List<ResponseParking> GetAllParkings()
        {
            return _repository.GetAllParkings().ConvertAll(p => new ResponseParking(p));
        }

        public Parking GetParking(int id)
        {
            return _repository.GetParkingById(id);
        }

        public void AddParking(Parking parking)
        {
            if (parking == null)
                return;

            ValidationResult result = _validator.Validate(parking);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            _repository.AddParking(parking);
        }

        public void UpdateParking(Parking parking)
        {
            if (parking == null)
                return;

            ValidationResult result = _validator.Validate(parking);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            _repository.UpdateParking(parking);
        }

        public void RemoveParking(int id)
        {
            _repository.RemoveParking(id);
        }
    }
}