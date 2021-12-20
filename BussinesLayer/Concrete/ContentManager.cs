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
    public class ContentManager : IContentService
    {
        IConcentDal _concentDal;
        public ContentManager(IConcentDal concentDal)
        {
            _concentDal = concentDal;
        }
        public void ConcentAddBl(Concent concent)
        {
            _concentDal.Insert(concent);
        }

        public void ConcentDelete(Concent concent)
        {
            _concentDal.Delete(concent);
        }

        public void ConcentUpdate(Concent concent)
        {
            _concentDal.Update(concent);
        }

        public Concent GetById(int Id)
        {
            return _concentDal.Get(x=>x.ConcentID==Id);
        }

        public List<Concent> GetList()
        {
            return _concentDal.List();
        }

        public List<Concent> GetListByHeadingId(int Id)
        {
            return _concentDal.List(x => x.HeadingID== Id);
        }

        public List<Concent> GetListByWriter(int Id)
        {
            return _concentDal.List(x => x.WriterID == Id);
        }
    }
}
