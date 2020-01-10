using System.ComponentModel.DataAnnotations;

namespace ProductStore.Models
{
    public class Currency
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }
    }
}