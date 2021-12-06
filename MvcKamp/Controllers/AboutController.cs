using BussinesLayer.Concrete;
using BussinesLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAboutList()
        {
            var AboutValues = aboutManager.GetList();
            return View(AboutValues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            AboutValidatior validationRules = new AboutValidatior();
            ValidationResult validationResult = validationRules.Validate(p);
            if(validationResult.IsValid)
            {
                aboutManager.AboutAddBl(p);
                return RedirectToAction("GetAboutList");
            }
            else 
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}