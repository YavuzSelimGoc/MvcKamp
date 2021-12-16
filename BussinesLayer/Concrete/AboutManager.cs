using BussinesLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _dal;
        public AboutManager(IAboutDal aboutDal)
        {
            _dal = aboutDal;
        }
        public void AboutAddBl(About about)
        {
            _dal.Insert(about);
        }

        public void AboutDelete(About about)
        {
            AboutUpdate(about);
            
        }

        public void AboutUpdate(About about)
        {
            _dal.Update(about);
        }

        public About GetById(int Id)
        {
            return _dal.Get(x => x.AboutID == Id);
        }

        public List<About> GetList()
        {
            return _dal.List();
        }
    }
}
