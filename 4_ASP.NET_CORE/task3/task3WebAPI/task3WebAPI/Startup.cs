﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using task3WebAPI.Context;
using task3WebAPI.Filters;
using task3WebAPI.Logger;
using task3WebAPI.MyLogger;
using task3WebAPI.Services;

namespace task3WebAPI
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<FilmsContext>(options =>
                options.UseSqlServer(connection));
            services.AddTransient<IFilmsService, FilmsService>();
            services.AddTransient<IMyFileLogger,MyFileLogger>();
            services.AddScoped<LogActionAttribute>();
            services.AddMvc().AddXmlDataContractSerializerFormatters();
   
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
