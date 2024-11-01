using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApi.Entities;

namespace TestApi.Validator
{
    public class ParkingValidator : AbstractValidator<Parking>
    {
        public ParkingValidator()
        {
            RuleFor(parking => parking.Name)
                .NotEmpty().WithMessage("Требуется указать название парковки.");

            RuleFor(parking => parking.Address)
                .NotEmpty().WithMessage("Требуется указать адрес парковки.");
        }
    }
}