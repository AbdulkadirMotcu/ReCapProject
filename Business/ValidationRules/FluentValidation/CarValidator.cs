using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    //Ekranlara göre DTO lara görede yapılabilir
    public class CarValidator : AbstractValidator<Car>
    {
        //Kurallar ctor içine yazılır...
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0); //0'dan Büyük olmalı
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(100).When(c => c.BrandId == 1);//100'den büyük olmalı ne zaman Brand
            
        }
    }
}
