using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        void HeadingAddBl(Heading heading);
        Heading GetById(int Id);
        void HeadingDelete(Heading heading);
        void HeadingUpdate(Heading heading);
        List<Heading> GetListByWriter(int Id);
    }
}
