using BussinesLayer.Concrete;
using BussinesLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using MvcKamp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.Controllers
{
    public class ContactController : BaseController
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidatior validationRules = new ContactValidatior();

        // GET: Contact
        public ActionResult Index()
        {
            var contactvalues = contactManager.GetList();
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int Id)
        {
            var ContactValues = contactManager.GetById(Id);
            return View(ContactValues);
        }
        public PartialViewResult ContactPartial()
        {
            ViewBag.ContactMessage = contactManager.GetList().Count();
            ViewBag.ReviceMessage = messageManager.GetListInBox(Mail).Count();
            ViewBag.SendMessage = messageManager.GetListSendBox(Mail).Count();
            ViewBag.UnRead = messageManager.GetInboxUnReadList(Mail).Count();
            ViewBag.Read = messageManager.GetInboxReadList(Mail).Count();
            return PartialView();
        }
    }
}