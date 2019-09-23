using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace webcore
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; set; }

        public Startup(IConfiguration configuration)
        {
            AppConfiguration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<FileManager>();
            services.AddSingleton<DoomRepo>();
            services.AddDbContext<DBC>(options => options.UseNpgsql(AppConfiguration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc(routing =>
            {
                routing.MapRoute("default", "{controller=Main}");
                routing.MapRoute("admin", "{controller=Panel}/{action=Modlist}");
                routing.MapRoute("file", "{controller=File}/{action=Modlist}/{id?}");
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("You went the wrong way, man.");
            });
        }
    }
}
