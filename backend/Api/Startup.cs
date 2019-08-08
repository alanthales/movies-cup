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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Domain.Entities;
using Domain.Interfaces;
using Repository;
using Repository.Providers;
using Service;
using Api.Middlewares;

namespace Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCustomErrorHandler();
            app.UseHttpsRedirection();

            app.UseCors(builder => 
                builder.AllowAnyHeader().AllowAnyMethod()
                .WithOrigins("http://localhost:5000/", "https://localhost:5001/")
            );

            app.UseMvc();
            app.UseFileServer();
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IHttpClient, MoviesApi>();
            services.AddScoped<IApiRepository<Filme>, MoviesRepository>();
            services.AddScoped<IMoviesService, MoviesService>();
        }
    }
}
