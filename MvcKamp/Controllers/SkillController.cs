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
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        // GET: Skill
        public ActionResult Index()
        {
            var SkillValue = skillManager.GetList();
            return View(SkillValue);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddSkill(Skill skill)
        {
            skillManager.SkillAddBl(skill);
           return RedirectToAction("Index");
            
        }
    }
}