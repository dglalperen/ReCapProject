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
    public class RentalValidator : AbstractValidator<Rental>
    {
        private readonly IRentalDal _rentalDal;

        public RentalValidator(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;

            RuleFor(r => r.Id).Must(UniqueRental).WithMessage(Messages.RentalAlreadyExistsError);
            RuleFor(r => r.ReturnDate).NotNull().WithMessage(Messages.RentalValidationError);
        }

        private bool UniqueRental(int id)
        {
            return _rentalDal.Get(r => r.Id == id) == null;
        }
    }
}
