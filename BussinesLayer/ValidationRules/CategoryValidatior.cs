using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules
{
    public class CategoryValidatior:AbstractValidator<Category>
    {
        public CategoryValidatior()
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori Adi Bos Gecilemez");
            RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("Kategori Aciklamasi Bos Gecilemez");
            RuleFor(x=>x.CategoryName).MinimumLength(2).WithMessage("Kategori Adi 2 Karakterden Fazla Olmalıdır");
            RuleFor(x=>x.CategoryName).MaximumLength(50).WithMessage("Kategori Adi 50 Karakterden Fazla Olmamalıdır");
        }
    }
}
