using Business.Constants;
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
    public class UserValidator : AbstractValidator<User>
    {
        private readonly IUserDal _userDal;

        public UserValidator(IUserDal userDal)
        {
            _userDal = userDal;

            RuleFor(u => u.Id).Must(UniqueUser).WithMessage(Messages.RentalAlreadyExistsError);
        }

        private bool UniqueUser(int id)
        {
            return _userDal.Get(u => u.Id == id) == null;
        }
    }
}
