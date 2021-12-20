using BussinesLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var AdminUserValue = adminManager.GetByUserNamePassword(admin.AdminUserName, admin.AdminPassword);
            if(AdminUserValue!=null)
            {
                FormsAuthentication.SetAuthCookie(AdminUserValue.AdminUserName,false);
                Session["AdminUserName"] = AdminUserValue.AdminUserName;
                return RedirectToAction("Index","AdminCategory");
            }
            else
            {
                ViewBag.ErrorMessage = "Bilgileri Kontrol Et";
                return View();
            }
    }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var WriterUserValue = writerManager.GetByUserNamePassword(writer.WriterMail, writer.WriterPassword);
            if (WriterUserValue != null)
            {
                FormsAuthentication.SetAuthCookie(WriterUserValue.WriterMail, false);
                Session["WriterMail"] = WriterUserValue.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                ViewBag.ErrorMessage = "Bilgileri Kontrol Et";
                return RedirectToAction("WriterLogin");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings","Default");
        }

    }
}