using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules
{
    public class AboutValidatior:AbstractValidator<About>
    {
        public AboutValidatior()
        {
            RuleFor(x=>x.AboutDetails1).NotEmpty().WithMessage("Detay Boş Geçilemez");
            RuleFor(x => x.AboutDetails1).MinimumLength(2).WithMessage("2 Karakterden Daha Düşük Veri Girişi Yapmayınız");
        }
    }
}
