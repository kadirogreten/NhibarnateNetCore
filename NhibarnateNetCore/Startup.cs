using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NhibarnateNetCore.ContextSession;
using NhibarnateNetCore.Extensions;
using NhibarnateNetCore.Map;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NhibarnateNetCore
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
            var connStr = Configuration.GetConnectionString("DefaultConnection");

            //var _sessionFactory = Fluently.Configure()
            //    .Database(PostgreSQLConfiguration.Standard.ConnectionString(connStr))
            //    .Mappings(x=>x.FluentMappings.AddFromAssembly(GetType().Assembly))
            //    .ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(false,true,false))
            //    .BuildSessionFactory();


            //services.AddScoped(f =>
            //{
            //    return _sessionFactory.OpenSession();
            //});
            services.AddNHibernate(connStr);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NhibarnateNetCore", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NhibarnateNetCore v1"));
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
