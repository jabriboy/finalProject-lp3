using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using finalProject_lp3.MODEL;
using finalProject_lp3.DAL.DBContext;
using Microsoft.EntityFrameworkCore.Internal;

namespace finalProject_lp3.BLL
{
    public static class MessagesRepository
    {
        public static Message addMessage(Message _m)
        {
            using (var dbContext = new DbContext())
            {
                dbContext.Add(_m);
                /*Chat c = ChatRepository.getById(_m.IdChat);
                if (c == null) { return null; }
                c.Messages.Add(_m);
                ChatRepository.updateChat(c);*/
                dbContext.SaveChanges();
            }
            return _m;
        }

        public static Message removeMessage(Message _m)
        {
            using (var dbContext = new DbContext())
            {
                dbContext.Remove(_m);
                dbContext.SaveChanges();
            }
            return _m;
        }

        public static Message getById(int id)
        {
            using (var dbContext = new DbContext())
            {
                try
                {
                    var message = dbContext.Messages.Single(p => p.Id == id);
                    return message;

                }
                catch
                {
                    return null;
                }
            }
        }

        public static List<Message> getAll()
        {
            using (var dbContext = new DbContext())
            {
                var messages = dbContext.Messages.ToList();
                return messages;
            }
        }
    }
}
