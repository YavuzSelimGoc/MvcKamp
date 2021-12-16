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
    public class LoginController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
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
    }
}