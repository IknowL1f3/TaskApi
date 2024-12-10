using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApi.Entities;

namespace TestApi.Validator
{
    public class ParkingEventValidator : AbstractValidator<ParkingEvent>
    {
        public ParkingEventValidator()
        {
            RuleFor(parkingEvent => parkingEvent.EntryTime)
                .NotEmpty().WithMessage("Требуется указать время заезда на парковки.");

            RuleFor(parkingEvent => parkingEvent.UserId)
                .NotEmpty().WithMessage("Требуется указать id пользователя.");

            RuleFor(parkingEvent => parkingEvent.ParkingId)
                .NotEmpty().WithMessage("Требуется указать id парковки.");
        }
    }
}