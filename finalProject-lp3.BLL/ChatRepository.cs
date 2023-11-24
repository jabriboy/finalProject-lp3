using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using finalProject_lp3.MODEL;
using finalProject_lp3.DAL.DBContext;

namespace finalProject_lp3.BLL
{
    public static class ChatRepository
    {
        public static Chat addChat(Chat _c)
        {
            using (var dbContext = new Dbcontext())
            {   
                // verifica se os usuarios exitem
                var user1 = UserRepository.getById(_c.IdUser1);
                var user2 = UserRepository.getById(_c.IdUser2);
                if(user1 == null || user2 == null || user1 == user2) { return null; }

                // verifica se já não existe um chat entre esses 2 usuários
                var sameChat = ChatRepository.getAll().ToList().FindAll(p => p.IdUser1 == user1.Id || p.IdUser1 == user2.Id && p.IdUser2 == user1.Id || p.IdUser2 == user2.Id);
                if(sameChat != null) { return null; }

                dbContext.Add(_c);
                dbContext.SaveChanges();
            }
            return _c;
        }

        public static Chat removeChat(Chat _c)
        {
            using (var dbContext = new Dbcontext())
            {
                dbContext.Remove(_c);
                dbContext.SaveChanges();
            }
            return _c;
        }

        public static Chat getById(int id)
        {
            using (var dbContext = new Dbcontext())
            {
                try
                {
                    var chat = dbContext.Chats.Single(p => p.Id == id);
                    return chat;

                }
                catch
                {
                    return null;
                }
            }
        }

        public static List<Chat> getAll()
        {
            using (var dbContext = new Dbcontext())
            {
                var chats = dbContext.Chats.ToList();
                return chats;
            }
        }

        /*public static Chat updateChat(Chat chat)
        {
            using (var dbContext = new Dbcontext())
            {   
                var _chat = dbContext.Chats.Single(c => c.Id == chat.Id);
                dbContext.Chats.Remove(_chat);
                dbContext.Add(chat);
                dbContext.SaveChanges();
            }

            return chat;
        }*/
    }
}
