using Microsoft.EntityFrameworkCore;
using SocialNetwork.Context;

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
                .GetConnectionString("LocalHostConnection");

            builder.Services.AddDbContext<SocialContext>(x => x.UseSqlServer(connectionStringLocalHost));

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}