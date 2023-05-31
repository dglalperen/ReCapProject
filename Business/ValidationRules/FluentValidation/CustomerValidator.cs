using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        private readonly ICustomerDal _customerDal;

        public CustomerValidator(ICustomerDal customerDal)
        {
            _customerDal = customerDal;

            RuleFor(customer => customer.Id)
                .Must(UniqueCustomer)
                .WithMessage(Messages.CarAlreadyExistsError);
        }

        private bool UniqueCustomer(int id)
        {
            return _customerDal.Get(c => c.Id == id) == null;
        }
    }
}
