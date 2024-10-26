using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TallerGestion.Data.Persistence;
using Microsoft.Extensions.Configuration;

namespace TallerGestion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    // Aquí agregamos el DbContextFactory
                    services.AddDbContextFactory<GestionContext>(options =>
                        options.UseMySQL(hostContext.Configuration.GetConnectionString("server=127.0.0.1;port=3306;database=gestion;user=root;password=tecnologo")));
                });
    }
}