using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task1WebAPI.Services
{
    public class SumService : ISumService
    {
        public int sum(int a, int b)
        {
            return a + b;
        }
    }
}
