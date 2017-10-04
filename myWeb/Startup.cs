using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using myWeb.Options;
using System;
using System.Net;

namespace myWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<EnvironementOptions>(options => {

                options.databaseOptions.DatabasePort = Configuration.GetSection("MYSQL_57_RHEL7_PORT_3306_TCP_PORT").Value;
                options.databaseOptions.DatabaseUser = Configuration.GetSection("MYSQL_USER").Value;
                options.databaseOptions.DatabasePassword = Configuration.GetSection("MYSQL_PASSWORD").Value;
                options.databaseOptions.DatabaseName = Configuration.GetSection("MYSQL_DATABASE").Value;
            });

            var test = Configuration.GetSection("MINISHIFT_PASSWORD");

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            //String hostname = Dns.GetHostName();

            //app.Run(context =>
            //{
            //    return context.Response.WriteAsync("The HOST running this app (VERSION 2) is named: " + hostname);
            //});
        }
    }
}
