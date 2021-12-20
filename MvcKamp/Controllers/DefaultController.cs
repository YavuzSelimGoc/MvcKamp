using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfConcentDal());
        // GET: Default
        public ActionResult Headings()
        {
            var values = headingManager.GetList();
            return View(values);
        }
        public PartialViewResult Index(int Id=0)
        {
            var contentlist = contentManager.GetListByHeadingId(Id);
            return PartialView(contentlist);
        }
    }
}