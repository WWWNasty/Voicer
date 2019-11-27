using System.Collections.Generic;
using DataAccessLayer.Models.Entities;

namespace DataAccessLayer.Models.Chats
{
    public class Chat: Entity<int>
    {
        public string Name { get; set; }

        public ICollection<Message> Message { get; set; }

        //public Voting Voting { get; set; }

    }
}