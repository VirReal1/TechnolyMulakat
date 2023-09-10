using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using TechnolyMulakat.Data;
using TechnolyMulakat.Repositories;

namespace TechnolyMulakat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            AddServices(builder);

            var app = builder.Build();
            ConfigureRequestPipeline(app);

            app.Run();
        }

        // Add services to the container.
        private static void AddServices(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("ConnectionStrings") ??
                throw new InvalidOperationException("Connection string 'ConnectionStrings' not found.");

            var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name; //QuickApplication

            builder.Services.AddDbContext<DataLayerContext>(options =>
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly(migrationsAssembly)));

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin();
                });
            });

            builder.Services.AddControllersWithViews();

            //! Repository Injections
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            //File Logger
            builder.Logging.AddFile(builder.Configuration.GetSection("Logging"));
        }

        // Configure the HTTP request pipeline.
        private static void ConfigureRequestPipeline(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html");
        }
    }
}