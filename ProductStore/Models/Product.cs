using System.ComponentModel.DataAnnotations;

namespace ProductStore.Models
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        [StringLength(20)]
        [Required]
        public string Unit { get; set; }

        [Required]
        public decimal Price { get; set; }

        [StringLength(20)]
        [Required]
        public string Currency { get; set; }

        public Category Category { get; set; }


        public int CategoryId { get; set; }
    }
}