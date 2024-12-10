using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApi.Entities;

namespace TestApi.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Требуется указать имя пользователя.");

            RuleFor(user => user.Surname)
                .NotEmpty().WithMessage("Требуется указать фамилию пользователя.");

            RuleFor(user => user.CarNumber)
                .NotEmpty().WithMessage("Требуется указать регистрационный номер пользователя.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Требуется указать пароль пользователя.");

        }
    }
}