using System.ComponentModel.DataAnnotations;

namespace Odev_1.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Ürün adı olmalıdır")]
        public string ProductName { get; set; }
        public double Price { get; set; }
        [Range(0,100)]
        public double Discount { get; set; }
    }
}
