using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using task3WebAPI.Models;

namespace task3WebAPI.Context
{
     public class FilmsContextInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                FilmsContext context = serviceScope.ServiceProvider.GetService<FilmsContext>();
                if (!context.Films.Any())
                {
                    context.Films.Add(new FilmModel { Name = "Test", Country = "USA", Year = 1783, Derictor = "Liza" });
                    context.Films.Add(new FilmModel { Name = "ITechArt", Country = "Belarus", Year = 2007, Derictor = "Liza" });
                    context.SaveChanges();
                }
                context.SaveChanges();
            }
        }
    }
}
