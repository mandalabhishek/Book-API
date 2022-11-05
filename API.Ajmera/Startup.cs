using API.Ajmera.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.Application;
using System;

namespace API.Ajmera
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }       

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<BookContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CurrentConnection")));
            services.AddScoped<IDbBookContext, BookContext>();
            services.AddHealthChecks()
                .AddSqlServer(
                "Data Source=.;Initial Catalog=master;Integrated Security=True"
                );
            services.AddSwaggerGen();
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Ajmera WEB API",
                    Version = "v1"
                });
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BookContext bookContext, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WEB API");
                c.DocumentTitle = "Ajmera WEB API";
            });

            loggerFactory.AddFile($"Logs/BookApiLog.txt");

            bookContext.Seed();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/Health");
            });
        }
    }
}
