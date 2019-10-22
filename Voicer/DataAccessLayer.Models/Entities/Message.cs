using System;

namespace DataAccessLayer.Models.Entities
{
    public class Message: Entity<int>
    {
        public string Text { get; set; }

        public DateTime Created { get; set; }

        public string User { get; set; }

    }
}