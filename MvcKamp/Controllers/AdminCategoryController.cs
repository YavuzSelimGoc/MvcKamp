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
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        // GET: AdminCategory
        [Authorize(Roles = "A")]
        public ActionResult Index()
        {
            var categoryvaluse = cm.GetList();
            return View(categoryvaluse);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidatior validations = new CategoryValidatior();
            ValidationResult result = validations.Validate(p);
            if(result.IsValid)
            {
                cm.CategoryAddBl(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            
            return View();
        }
        public ActionResult DeleteCategory(int Id)
        {
            var CategoryValue = cm.GetById(Id);
            cm.CategoryDelete(CategoryValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int Id)
        {
            var CategoryValue = cm.GetById(Id);
            return View(CategoryValue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            cm.CategoryUpdate(category);
            return RedirectToAction("Index");
        }


    }
}