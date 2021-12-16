using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());
        // GET: Galery
        public ActionResult Index()
        {
            var ImageFileValues = imageFileManager.GetList();
            return View(ImageFileValues);
        }
    }
}