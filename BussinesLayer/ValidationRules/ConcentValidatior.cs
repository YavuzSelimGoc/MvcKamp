using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules
{
    public class ConcentValidatior:AbstractValidator<Concent>
    {
        public ConcentValidatior()
        {
            RuleFor(x=>x.ConcentValue).NotEmpty().WithMessage("Bu Alan Bos Gecilemez");
        }
    }
}
