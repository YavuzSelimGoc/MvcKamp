using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules
{
    public class ContactValidatior:AbstractValidator<Contact>
    {
        public ContactValidatior()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("ADINIZI BOŞ GEÇMEYİNİZ");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("MAİLİ BOŞ GEÇMEYİNİZ");
            RuleFor(x => x.Message).NotEmpty().WithMessage("MESAJI BOŞ GEÇMEYİNİZ");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("KONUYU BOŞ GEÇMEYİNİZ");
        }
    }
}
