using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.DataLayer.Models;
using SocialNetwork.DataLayer.ViewModels.Account;


namespace SocialNetwork.Context
{
    public class SocialContext : IdentityDbContext
    {
        public SocialContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Followre> Followres { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<SocialNetwork.DataLayer.ViewModels.Account.RegisterViewModel> RegisterViewModel { get; set; }


        public DbSet<SocialNetwork.DataLayer.ViewModels.Account.LoginViewModel> LoginViewModel { get; set; }
    }
}