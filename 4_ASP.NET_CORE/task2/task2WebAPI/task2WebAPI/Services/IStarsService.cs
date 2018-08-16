using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task2WebAPI.Models;

namespace task2WebAPI.Services
{
    public interface IStarsService
    {
        StarsResultWithNext GetStarsSync();
        Task<StarsResultWithNext> GetStarsAsync();
        Task<StarsResultWithNext> GetAllStarsAsync();
    }
}
