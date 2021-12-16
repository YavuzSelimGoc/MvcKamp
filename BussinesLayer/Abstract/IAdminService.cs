using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();
        void AdminAddBl(Admin admin);
        Admin GetById(int Id);
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);
        Admin GetByUserName(string UserName);
        Admin GetByUserNamePassword (string UserName,string Password);
        bool log(string user, string password);
    }
}
