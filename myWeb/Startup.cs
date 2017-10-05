using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        private String MySqlConnection { set; get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //"MySqlConnection": "server=localhost;port=3306;database=IdSrv;user=xxxx;password=xxxx"

            //MySqlConnection = $"server={Configuration.GetSection("MYSQL_57_RHEL7_SERVICE_HOST").Value};" +
            //                  $"port={Configuration.GetSection("MYSQL_57_RHEL7_PORT_3306_TCP_PORT").Value};" +
            //                  $"database={Configuration.GetSection("MYSQL_DATABASE").Value};" +
            //                  $"user={Configuration.GetSection("MYSQL_USER").Value};" +
            //                  $"password={Configuration.GetSection("MYSQL_PASSWORD").Value}";

            //get environement value out of openshift mysql image
            MySqlConnection = Configuration.GetSection("MYSQL_CONNECTION_USER").Value;

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

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action=Index}/{id?}");
            //});

            String hostname = Dns.GetHostName();

           

            app.Run(context =>
            {
                return context.Response.WriteAsync($"The HOST running this app (VERSION 1) is named: {hostname} and connection: {MySqlConnection}");
            });
        }
    }
}
