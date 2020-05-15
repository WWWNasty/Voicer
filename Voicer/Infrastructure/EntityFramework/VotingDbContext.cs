using System;
using DataAccessLayer.Models.Chats;
using DataAccessLayer.Models.Users;
using DataAccessLayer.Models.Votes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.EntityFramework
{ 
    public class VotingDbContext :  IdentityDbContext<User>
    {
        

        public VotingDbContext(DbContextOptions<VotingDbContext> options)
            : base(options)
        {

        }
        
        public DbSet<Voting> Voting { get; set;}
        
        public DbSet<VotingOption> VotingOptions { get; set; }

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
            
            modelBuilder.Entity<Voting>()
                .HasMany(voting => voting.VotingOptions)
                .WithOne(option => option.Voting)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Voting>()
                .HasMany(voting => voting.Votes)
                .WithOne(option => option.Voting)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
