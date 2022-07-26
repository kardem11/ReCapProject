using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ModelYear).GreaterThan(2017);
            RuleFor(c => c.Description).Must(StartWithH).WithMessage("Car name start with H");
        }
        private bool StartWithH(string arg)
        {
            return arg.StartsWith("H");
        }
    }
}
