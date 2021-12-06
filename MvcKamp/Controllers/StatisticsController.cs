using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.Controllers
{
    public class StatisticsController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: Statistics
        public ActionResult Index()
        {
            ViewBag.CategoryNumber = cm.GetList().Count();
            ViewBag.ForCategory = hm.GetList().Where(x => x.CategoryID == 20).Count();
            ViewBag.InAChar = wm.GetList().Where(x => x.WriterName.Contains("a") || x.WriterName.Contains("A")).Count();
            ViewBag.MoreCategory = cm.GetList().Where(x => x.CategoryID ==(hm.GetList().GroupBy(h => h.CategoryID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.CategoryName).FirstOrDefault();
            ViewBag.TrueStatus = cm.GetList().Where(x => x.CategoryStatus == true).Count();
            return View();
        }
    }
}