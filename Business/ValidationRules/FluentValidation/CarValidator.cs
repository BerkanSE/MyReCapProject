using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).MinimumLength(2);
            RuleFor(c => c.CarName).NotEmpty().WithMessage("Name cannot be null");
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Daily price must be great than 0");
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.ModelYear).GreaterThan(2000);
            RuleFor(c => c.ModelYear).LessThanOrEqualTo(DateTime.Now.Year);
        }
        
    }
}
