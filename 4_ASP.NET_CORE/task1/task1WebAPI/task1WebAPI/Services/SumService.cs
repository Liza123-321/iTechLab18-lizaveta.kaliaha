using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task1WebAPI.Models;

namespace task1WebAPI.Services
{
    public class SumService : ISumService
    {
        public SumModel Sum(DataModel data)
        {
            return new SumModel { A=(int)data.A,B=(int)data.B,Sum=(int)(data.A+data.B)};
        }
    }
}
