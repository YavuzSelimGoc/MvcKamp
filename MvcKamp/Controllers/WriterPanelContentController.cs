using BussinesLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using MvcKamp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKamp.Controllers
{
    public class WriterPanelContentController : BaseController
    {
        ContentManager contentManager = new ContentManager(new EfConcentDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        Context context = new Context();
        // GET: WriterPanelContent
        public ActionResult MyContent(string mail)
        {
            
            mail = (string)Session["WriterMail"];
            var value = context.Writer.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            var Values2=contentManager.GetListByWriter(value);
            return View(Values2);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Concent concent)
        {
            string mail;
            mail = (string)Session["WriterMail"];
            var value = context.Writer.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            concent.ConcentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            concent.WriterID = value;
            concent.ContentStatus = true;
            contentManager.ConcentAddBl(concent);
            return RedirectToAction("MyContent");
        }
        public ActionResult ToDoList()
        {
            return View();
        }
    }
}