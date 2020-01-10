using System.Collections.Generic;

namespace ProductStore.Dtos
{
    public class ProductFormData
    {
        public IList<string> Unit { get; set; }
        public IList<string> Currency { get; set; }
    }
}