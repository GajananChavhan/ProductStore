using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductStore.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public IList<Product> Products { get; set; }
    }
}