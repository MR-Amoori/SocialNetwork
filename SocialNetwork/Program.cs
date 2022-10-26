using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Context;
using SocialNetwork.DataLayer.Repositories;
using SocialNetwork.DataLayer.Services;

namespace SocialNetwork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllersWithViews();

            #region Context

            var connectionStringLocalHost = builder.Configuration
                .GetConnectionString("LocalHostConnection2");

            builder.Services.AddDbContext<SocialContext>(x => x.UseSqlServer(connectionStringLocalHost));

            #endregion

            #region IOC

            builder.Services.AddScoped<IUserRepository, UserRepository>();

            #endregion

            #region Authentication

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                    options.ExpireTimeSpan = TimeSpan.FromDays(7);
                });

            #endregion

            var app = builder.Build();


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}