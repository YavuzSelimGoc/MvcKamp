using BussinesLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcKamp.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headinManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        Context context = new Context();
        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterMail"];
            var WriterValue = context.Writer.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var HeadingValues = headinManager.GetListByWriter(WriterValue);
            return View(HeadingValues);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> ValueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.vlc = ValueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            var deger = (string)Session["WriterMail"];
            var WriterValue = context.Writer.Where(x => x.WriterMail == deger).Select(y => y.WriterID).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = WriterValue;
            heading.HeadingStatus = true;
            headinManager.HeadingAddBl(heading);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int Id)
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
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int Id)
        {
            var HeadingSelected = headinManager.GetById(Id);
            HeadingSelected.HeadingStatus = HeadingSelected.HeadingStatus == true ? false : true;
            headinManager.HeadingDelete(HeadingSelected);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading (int PageNumber=1)
        {
            var headigs = headinManager.GetList().ToPagedList(PageNumber, 8);
            return View(headigs);
        }
    }
}