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

        public About GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
        {
            return _dal.List();
        }
    }
}
