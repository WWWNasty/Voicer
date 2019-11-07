using System;
using DataAccessLayer.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace VotingApp.Infrastructure.DataAccess
{ 
    public class VotingDbContext : DbContext
    {
        

        public VotingDbContext(DbContextOptions<VotingDbContext> options)
            : base(options)
        {

        }
        
        public DbSet<Voting> Voting { get; set;}
        
        public DbSet<VotingOption> VotingOption { get; set; }

        public DbSet<Vote> Votes { get; set; }
        
        public DbSet<Chat> Chats { get; set; }
        
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Voting>().HasData(
                new Voting()
                {
                    Id = -1, Name = "Where will be the new year's corporate party", Description = "every year...", StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(12)
                },

                new Voting()
                {
                    Id = -2, Name = "Elections of the President of Ukraine", Description = "Petia or Zelia", StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(12)
                });

        }
    }
}
