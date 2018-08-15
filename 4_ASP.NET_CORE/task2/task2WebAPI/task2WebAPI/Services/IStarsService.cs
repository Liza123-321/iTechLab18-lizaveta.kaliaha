using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task2WebAPI.Models;

namespace task2WebAPI.Services
{
    public interface IStarsService
    {
        StarsResult GetStarsSync();
        Task<StarsResult> GetStarsAsync();
        Task<StarsResult> GetAllStarsAsync();
    }
}
