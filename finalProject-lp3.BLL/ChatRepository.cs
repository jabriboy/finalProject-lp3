﻿using System;
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
        public static Chat addUser(Chat _c)
        {
            using (var dbContext = new DbContext())
            {
                dbContext.Add(_c);
                dbContext.SaveChanges();
            }
            return _c;
        }

        public static Chat removeUser(Chat _c)
        {
            using (var dbContext = new DbContext())
            {
                dbContext.Remove(_c);
                dbContext.SaveChanges();
            }
            return _c;
        }

        public static Chat getById(int id)
        {
            using (var dbContext = new DbContext())
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
            using (var dbContext = new DbContext())
            {
                var chats = dbContext.Chats.ToList();
                return chats;
            }
        }
    }
}