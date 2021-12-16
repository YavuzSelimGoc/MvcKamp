using BussinesLayer.Abstract;
using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager headinManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var HeadingValues = headinManager.GetList();
            return View(HeadingValues);
        }
        [HttpGet]

        public ActionResult AddHeading()
        {
            List<SelectListItem> WriterValue = (from w in writerManager.GetList()
            select new SelectListItem { Text=w.WriterName + ""+ w.WriterSurname, Value=w.WriterID.ToString()}).ToList();
            ViewBag.vlw = WriterValue;
            List<SelectListItem> ValueCategory = (from x in categoryManager.GetList() 
        select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.vlc = ValueCategory;
            return View();
        }

        [HttpPost]

        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate =DateTime.Parse( DateTime.Now.ToShortDateString());
            headinManager.HeadingAddBl(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int Id )
        {
            List<SelectListItem> ValueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.vlc = ValueCategory;
            var HeadingValue = headinManager.GetById(Id);

            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headinManager.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int Id)
        {
            var HeadingSelected = headinManager.GetById(Id);
            HeadingSelected.HeadingStatus = HeadingSelected.HeadingStatus == true ? false : true;
            headinManager.HeadingDelete(HeadingSelected);
            return RedirectToAction("Index");
        }
    }
}