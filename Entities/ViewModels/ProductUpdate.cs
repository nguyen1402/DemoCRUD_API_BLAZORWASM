using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModels
{
    public class ProductUpdate
    {
        
        [Required(ErrorMessage = "Tên phải có")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mô tả phải có")]
        public string Description { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Giá từ  1 trở lên")]
        public double Price { get; set; }
    }
}
