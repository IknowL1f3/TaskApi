using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApi.Entities;

namespace TestApi.Validator
{
    public class BalanceValidator : AbstractValidator<Balance>
    {
        public BalanceValidator()
        {
            
        }
    }
}