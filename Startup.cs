using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerGestion.Data;
using TallerGestion.Data.Persistence;
using TallerGestion.Hubs;
using static K4os.Compression.LZ4.Engine.Pubternal;

namespace TallerGestion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSignalR();
            services.AddDbContext<GestionContext>(o => o.UseMySQL(Configuration.GetConnectionString("Default")));
            services.AddDbContextFactory<GestionContext>(o => o.UseMySQL(Configuration.GetConnectionString("Default")), ServiceLifetime.Scoped);
            services.AddScoped<AtencionesService>();
            services.AddScoped<OficinasComercialService>();
            services.AddScoped<PuestosAtencionService>();
            services.AddScoped<GestionCalidadService>();
            services.AddQuickGridEntityFrameworkAdapter();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapHub<AtencionHub>("/atencionHub");
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
