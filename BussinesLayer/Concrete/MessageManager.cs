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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public Message GetById(int Id)
        {
            return _messageDal.Get(x=>x.MessageID==Id);
        }

        public List<Message> GetList()
        {
            return _messageDal.List();
        }

        public List<Message> GetListInBox(string mail)
        {
            return _messageDal.List(x => x.ReceiverMail == mail);
        }

        public List<Message> GetListSendBox(string mail)
        {
            return _messageDal.List(x => x.SenderMail == mail);
        }

        public List<Message> GetInboxReadList(string mail)
        {
            return _messageDal.List(x =>x.ReceiverMail==mail && x.MessageRead == true);
        }

        public List<Message> GetInboxUnReadList(string mail)
        {
            return _messageDal.List(x => x.ReceiverMail == mail && x.MessageRead == false);
        }

        public void MessageAddBl(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

       
    }
}
