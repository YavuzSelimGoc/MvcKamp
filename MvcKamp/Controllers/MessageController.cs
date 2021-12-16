using BussinesLayer.Concrete;
using BussinesLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using MvcKamp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.Controllers
{
    public class MessageController : BaseController
    {
        
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidatior messageValidatior = new MessageValidatior();

        // GET: Message
        [Authorize]
        public ActionResult Inbox()
        {
            var MessageValue = messageManager.GetListInBox(Mail);
            return View(MessageValue);
        }

        public ActionResult Sendbox()
        {
            var MessageValue = messageManager.GetListSendBox(Mail);
            return View(MessageValue);
        }
        public ActionResult GetInBoxMessageDetails(int Id)
        {
            
            var MessageValues = messageManager.GetById(Id);
            MessageValues.MessageRead = true;
            messageManager.MessageUpdate(MessageValues);
            return View(MessageValues);
           
        }
        public ActionResult GetSendMessageDetails(int Id)
        {
            
            var MessageValues = messageManager.GetById(Id);
            return View(MessageValues);
        }

       [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
          
            
            ValidationResult results = messageValidatior.Validate(message);
            if (results.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAddBl(message);
                return RedirectToAction("SendBox");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        
    }
     
    }
}