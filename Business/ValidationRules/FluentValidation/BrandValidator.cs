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
    public class BrandValidator : AbstractValidator<Brand>
    {
        private readonly IBrandDal _brandDal;

        public BrandValidator(IBrandDal brandDal)
        {
            _brandDal = brandDal;

            RuleFor(brand => brand.Id)
                .Must(UniqueBrand)
                .WithMessage(Messages.BrandAlreadyExistsError);
        }

        private bool UniqueBrand(int id)
        {
            return _brandDal.Get(b => b.Id == id) == null;
        }
    }
}
