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
            var AbaoutValues = aboutManager.GetList();
            return View(AbaoutValues);
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
                return RedirectToAction("Index");
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
        public ActionResult Delete(int Id)
        {
            var key = aboutManager.GetById(Id);
            key.AboutStatus = !key.AboutStatus;
            aboutManager.AboutDelete(key);
            return RedirectToAction("Index");
        }

    }
}