using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    interface IContactService
    {
        List<Contact> GetList();
        void ContactAddBl(Contact contact);
        Contact GetById(int Id);
        void ContactDelete(Contact contact);
        void ContactUpdate(Contact contact);
    }
}
