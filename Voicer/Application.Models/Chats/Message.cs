using System;
using DataAccessLayer.Models.Entities;

namespace DataAccessLayer.Models.Chats
{
    public class Message: Entity<int>
    {
        public string Text { get; set; }

        public DateTime Created { get; set; }

        public string User { get; set; }

    }
}