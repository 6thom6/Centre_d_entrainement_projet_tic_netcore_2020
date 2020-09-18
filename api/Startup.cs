using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using api.Helpers;
using System.Data.Common;
using System.Data.SqlClient;
using DAL.Repository;
using Tools.Database;
using DAL.IRepository;

namespace api
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
            IConfigurationSection dbConnexionStringSection = Configuration.GetSection("db_ConnexionStrings");
            DBConnexionStrings dBConnexionStrings = dbConnexionStringSection.Get<DBConnexionStrings>();
            string ConnectionStrings = dbConnexionStringSection.Get<DBConnexionStrings>().ConnexionStrings;


            services.AddControllers();
            services.AddSingleton<DbProviderFactory>(sp => SqlClientFactory.Instance);
            services.AddSingleton(sp => new ConnectionInfo(ConnectionStrings));
            services.AddSingleton<Connection>();
            services.AddSingleton<ChevalRepository>();
            services.AddSingleton<CourseRepository>();
         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
