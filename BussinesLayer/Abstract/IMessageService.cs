using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetList();
        List<Message> GetListInBox(string mail);
        List<Message> GetListSendBox(string mail);
        List<Message> GetInboxReadList(string mail);
        List<Message> GetInboxUnReadList(string mail);
        void MessageAddBl(Message message);
        Message GetById(int Id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
