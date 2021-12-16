using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules
{
    public class WriterValidatior:AbstractValidator<Writer>
    {
        public WriterValidatior()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adi Alani Bos Gecilemez");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadi Alani Bos Gecilemez");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Unvani Alani Bos Gecilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("E-Mail Alani Bos Gecilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Sifre  Alani Bos Gecilemez");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkinda  Alani Bos Gecilemez");
            RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Lütfen Resim Seciniz");
            RuleFor(x => x.WriterAbout).MinimumLength(5).WithMessage("Hakkinda  Alani 5 Karakterden Küçük Olamaz");

        }
    }
}
