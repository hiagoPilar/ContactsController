using ControleDeContatos.Data;
using ControleDeContatos.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace ControleDeContatos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            

            builder.Services.AddDbContext<BancoContext>
                (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

            builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
