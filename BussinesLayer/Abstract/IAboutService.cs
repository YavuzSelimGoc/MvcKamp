using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();
        void AboutAddBl(About about);
        About GetById(int Id);
        void AboutDelete(About about);
        void AboutUpdate(About about);
    }
}
