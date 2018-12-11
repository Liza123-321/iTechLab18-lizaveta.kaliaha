using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmsCatalog.Business;
using FilmsCatalog.Business.Interfaces;
using FilmsCatalog.Business.Logger;
using FilmsCatalog.Business.Logger.Filters;
using FilmsCatalog.Business.Models;
using FilmsCatalog.Business.Services;
using FilmsCatalog.Business.SignalR;
using FilmsCatalog.DAL.Context;
using FilmsCatalog.DAL.Interfaces;
using FilmsCatalog.DAL.Models;
using FilmsCatalog.DAL.Repository;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.Edm;

namespace WebApi
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
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connection));
            //string con = "Server=localhost;Database=filmsCatalog;Trusted_Connection=True;";
            //services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(con));
            services.AddCors();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.RequireHttpsMetadata = false;
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           // укзывает, будет ли валидироваться издатель при валидации токена
                           ValidateIssuer = true,
                           // строка, представляющая издателя
                           ValidIssuer = AuthOptions.ISSUER,
                           // будет ли валидироваться потребитель токена
                           ValidateAudience = true,
                           // установка потребителя токена
                           ValidAudience = AuthOptions.AUDIENCE,
                           // будет ли валидироваться время существования
                           ValidateLifetime = true,
                           // установка ключа безопасности
                           IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                           // валидация ключа безопасности
                           ValidateIssuerSigningKey = true,
                       };
                   });
            services.AddSingleton<ILog4NetService, Log4NetService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPhotoGalleryService, PhotoGalleryService>();
            services.AddScoped<IODataService, ODataService>();


            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();

            services.AddOData();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(LogActionAttribute));
                options.Filters.Add(typeof(LogExceptionAttribute));

            }).AddXmlDataContractSerializerFormatters();
            services.AddAutoMapper();
            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseSignalR(routes =>
            {
                routes.MapHub<CommentHub>("/comment");
            });
            app.UseMvc(b =>
            {
                b.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
                b.MapODataServiceRoute("odata", "odata", GetEdmModel());
                b.EnableDependencyInjection();
            });
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<User>("Users");
            builder.EntitySet<Photo>("Photos");
            builder.EntitySet<RatingMark>("RatingMarks");
            builder.EntitySet<FilmsCatalog.DAL.Models.Genre>("Genres");
            builder.EntitySet<FilmsCatalog.DAL.Models.Comment>("Comments");
            builder.EntitySet<FilmsCatalog.DAL.Models.Film>("Films");

            return builder.GetEdmModel();
        }
    }
}
