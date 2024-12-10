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
    public class BalanceBLL
    {
        private BalanceRepository _repository = new BalanceRepository();
        private BalanceValidator _validator = new BalanceValidator();

        public List<ResponseBalance> GetAllBalances()
        {
            return _repository.GetAllBalances().ConvertAll(b => new ResponseBalance(b));
        }

        public Balance GetBalance(int id)
        {
            return _repository.GetBalanceById(id);
        }

        public void AddBalance(Balance balance)
        {
            if (balance == null)
                return;

            ValidationResult result = _validator.Validate(balance);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            _repository.AddBalance(balance);
        }

        public void UpdateBalance(Balance balance)
        {
            if (balance == null)
                return;

            ValidationResult result = _validator.Validate(balance);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            _repository.UpdateBalance(balance);
        }

        public void RemoveBalance(int id)
        {
            _repository.RemoveBalance(id);
        }
    }
}