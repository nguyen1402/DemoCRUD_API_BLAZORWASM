using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên phải có")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mô tả phải có")]
        public string Description { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Giá từ  1 trở lên")]
        public double Price { get; set; }
    }
}
