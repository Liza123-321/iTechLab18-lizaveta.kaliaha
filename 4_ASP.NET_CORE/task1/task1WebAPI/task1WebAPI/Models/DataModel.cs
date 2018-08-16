using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task1WebAPI.Models
{
    public class DataModel
    {
        [Required(ErrorMessage = "Параметр a обязателен")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Параметр a должен быть строго положительным")]
        public int? A { get; set; }
        [Required(ErrorMessage = "Параметр b обязателен")]
        [Range(Int32.MinValue, -1, ErrorMessage = "Параметр b должен быть строго отрицательным")]
        public int? B { get; set; }
    }
}
