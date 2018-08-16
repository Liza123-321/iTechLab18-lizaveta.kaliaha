using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task1WebAPI.Models;

namespace task1WebAPI.Services
{
    public interface ISumService
    {
        SumModel Sum(DataModel data);
     }
}
