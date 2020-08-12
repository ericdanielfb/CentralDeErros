using AutoMapper;
using CentralDeErros.API.Configuration;
using CentralDeErros.Core;
using CentralDeErros.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace CentralDeErros.API
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

            services.AddDbContext<CentralDeErrosDbContext>(options 
                => options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

            services.AddIdentityConfiguration(Configuration);

           
            services.AddScoped<ErrorService>();
            services.AddScoped<EnvironmentService>();
            services.AddScoped<LevelService>();
            services.AddScoped<MicrosserviceService>();
            services.AddScoped<ProfileService>();
            services.AddScoped<TokenGeneratorService>();

            services.AddScoped<UserService>();

            services.AddSwaggerGen(x => {
                x.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                x.AddSecurityRequirement(
                    new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Description = "Adds token to header",
                                Name = "Authorization",
                                Type = SecuritySchemeType.Http,
                                In = ParameterLocation.Header,
                                Scheme = "bearer",
                                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                            },
                            new List<string>()
                        }
                    }
                );
                
            });

            services.AddAutoMapper(typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Central De Erros");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
