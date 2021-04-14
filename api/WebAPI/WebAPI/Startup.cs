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
using WebAPI.Domain.Repositories.MSSQL;
using WebAPI.Domain.Services;
using WebAPI.Domain.UnitOfWork;
using WebAPI.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain;
using Microsoft.OpenApi.Models;
using WebAPI.Mapping;

namespace WebAPI
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
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddCors(opts =>
            {
                opts.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });

                ////API'mýzý kýsýtlamak istediðimiz zaman kullanacaðýmýz Policy yani dýþarýya kapalý sadece bizim belirttiðimiz noktalardan gelen isteklere açýk olacak.
                //opts.AddPolicy("GarsoonAppPolicy", builder =>
                //{
                //    builder.WithOrigins("https://fotokopicim1.com").AllowAnyHeader().AllowAnyMethod();
                //    builder.WithOrigins("https://fotokopicim2.com").AllowAnyHeader().AllowAnyMethod();
                //});
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation  
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Ard Test API"
                });
            });

            services.AddControllers();

            services.AddDbContext<ArdTestContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:MsSqlConnectionString"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ard Test API");
            });

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
