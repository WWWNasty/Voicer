using System;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.Users;

namespace DataAccessLayer.Models.Chats
{
    public class Message : IEntity<int>
    {
        public int Id { get; set; }

        [Required] public string Text { get; set; }

        [Required] public DateTime Created { get; set; } = DateTime.UtcNow;

        [Required] public string UserId { get; set; }

        public User User { get; set; }

        [Required] public int ChatId { get; set; }
    }
}