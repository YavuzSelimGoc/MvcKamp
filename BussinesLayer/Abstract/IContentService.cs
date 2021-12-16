using BussinesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    interface IContentService
    {
        List<Concent> GetList();
        List<Concent> GetListByHeadingId(int Id);
        void ConcentAddBl(Concent concent);
        Concent GetById(int Id);
        void ConcentDelete(Concent concent);
        void ConcentUpdate(Concent concent);

    }
}
