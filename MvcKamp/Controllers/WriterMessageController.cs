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
    public class WriterMessageController : BaseController
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidatior messageValidatior = new MessageValidatior();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inbox(string mail)
        {
            mail = (string)Session["WriterMail"];
            var MessageValue = messageManager.GetListInBox(mail);
            return View(MessageValue);
        }
        public ActionResult Sendbox(string mail)
        {
            mail = (string)Session["WriterMail"];
            var MessageValue = messageManager.GetListSendBox(mail);
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
                message.SenderMail = Mail;
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
        public PartialViewResult MessagePartial()
        {
            return PartialView();
        }

    }
}