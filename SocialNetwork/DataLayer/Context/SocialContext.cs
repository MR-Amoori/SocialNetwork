using Microsoft.EntityFrameworkCore;
using SocialNetwork.DataLayer.Models;
using SocialNetwork.DataLayer.ViewModels;

namespace SocialNetwork.Context
{
    public class SocialContext : DbContext
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
            modelBuilder.Entity<LoginViewModel>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }




        public DbSet<SocialNetwork.DataLayer.ViewModels.RegisterViewModel> RegisterViewModel { get; set; }




        public DbSet<SocialNetwork.DataLayer.ViewModels.LoginViewModel> LoginViewModel { get; set; }
    }
}