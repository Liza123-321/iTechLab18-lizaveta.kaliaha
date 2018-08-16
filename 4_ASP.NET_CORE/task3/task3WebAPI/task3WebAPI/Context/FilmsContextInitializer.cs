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
    public static class FilmsContextInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmModel>().HasData(
             new FilmModel {Id = 1, Name = "Test", Country = "USA", Year = 1783, Derictor = "Liza" },
             new FilmModel { Id = 2, Name = "ITechArt", Country = "Belarus", Year = 2007, Derictor = "Liza" });

        }
    }
}
