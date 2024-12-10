using FluentValidation;
using FluentValidation.Results;
using Microsoft.Ajax.Utilities;
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
    public class UserBLL
    {
        private UserRepository _repository = new UserRepository();
        private UserValidator _validator = new UserValidator();

        public List<ResponseUser> GetAllUsers()
        {
            return _repository.GetAllUsers().ConvertAll(u => new ResponseUser(u));
        }

        public User GetUser(int id)
        {
            return _repository.GetUserById(id);
        }

        public User GetUserByCarNumber(string carNumber)
        {
            return _repository.GetUserByCarNumber(carNumber);
        }

        public void AddUser(User user)
        {
            if (user == null)
                return;

            ValidationResult result = _validator.Validate(user);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);          

            BalanceBLL balanceBLL = new BalanceBLL();
            Balance balance = new Balance();
            balanceBLL.AddBalance(balance);

            user.BalanceId = balance.BalanceId;

            _repository.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
                return;

            ValidationResult result = _validator.Validate(user);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            _repository.UpdateUser(user);
        }

        public void RemoveUser(int id)
        {
            _repository.RemoveUser(id);
        }
    }
}