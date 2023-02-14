using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExampeSDP211.Data;

namespace ExampeSDP211
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
            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Weather API",
                    Description = "This is weahter forecast example fpr studenst IT Step",
                    TermsOfService = new Uri("https://learn.microsoft.com/"),
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Zhassulan",
                        Email = "zhasulanasainov@gmail.com",
                        Url = new Uri("https://learn.microsoft.com/")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "Weather Fprecast Open license",
                        Url = new Uri("https://learn.microsoft.com/")
                    }
                });
            });

            services.AddDbContext<ExampeSDP211Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ExampeSDP211Context")));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c=> { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
