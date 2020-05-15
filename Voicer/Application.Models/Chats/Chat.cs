using System.Collections.Generic;
using DataAccessLayer.Models.Entities;

namespace DataAccessLayer.Models.Chats
{
    public class Chat : IEntity<int>
    {
        public int Id { get; set; }

        //public string Name { get; set; }

        public ICollection<Message> Message { get; set; }

        //public Voting Voting { get; set; }
    }
}