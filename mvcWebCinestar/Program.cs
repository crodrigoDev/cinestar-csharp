using mvcWebCinestar.Controllers.bd;
using mvcWebCinestar.Controllers.dao;

namespace mvcWebCinestar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<clsBD>();
            builder.Services.AddScoped<daoCine>();
            builder.Services.AddScoped<daoPelicula>();
            builder.Services.AddScoped<HttpClient>();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Cine}/{action=Inicio}/{id?}");

            app.Run();
        }
    }
}
