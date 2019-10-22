using System.Collections.Generic;

namespace DataAccessLayer.Models.Entities
{
    public class Chat: Entity<int>
    {
        public string Name { get; set; }

        public ICollection<Message> Message { get; set; }

        public Voting Voting { get; set; }

    }
}