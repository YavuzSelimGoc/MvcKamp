using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules
{
   public class MessageValidatior:AbstractValidator<Message>
    {
        public MessageValidatior()
        {
            //RuleFor(x=>x.SenderMail).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x=>x.ReceiverMail).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x=>x.Subject).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x=>x.MessageContent).NotEmpty().WithMessage("Bu alan boş geçilemez");
            //RuleFor(x=>x.MessageDate).NotEmpty().WithMessage("Bu alan boş geçilemez");
        }
    }
}
