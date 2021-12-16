using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface ISkillService
    {
        List<Skill> GetList();
        void SkillAddBl(Skill skill);
        Skill GetById(int Id);
        void SkillDelete(Skill skill);
        void SkillUpdate(Skill skill);
    }
}
