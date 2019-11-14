using System;
using DataAccessLayer.Models.Chats;
using DataAccessLayer.Models.Users;
using DataAccessLayer.Models.Votes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
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
            
            modelBuilder.Entity<UserVoting>()
                .HasKey(userVoting => new { userVoting.VotingId, userVoting.UserId });
            modelBuilder.Entity<UserVoting>()
                .HasOne(userVoting => userVoting.Voting)
                .WithMany(voting => voting.Participants)
                .HasForeignKey(userVoting => userVoting.VotingId);
            modelBuilder.Entity<UserVoting>()
                .HasOne(userVoting => userVoting.User)
                .WithMany(user => user.UserVoting)
                .HasForeignKey(userVoting => userVoting.UserId);


        }
    }
}
