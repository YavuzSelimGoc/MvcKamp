using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfConcentDal());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int Id)
        {
            var ContentValues = contentManager.GetListByHeadingId(Id);
            return View(ContentValues);
        }
    }
}