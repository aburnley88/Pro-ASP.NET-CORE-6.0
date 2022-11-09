using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models
{
    public class Product
    {
        public long? ProductID { get; set; }
        public string ProductName { get; set; } = String.Empty;
        public string ProductDescription { get; set; } = String.Empty;
        [Column(TypeName = "decimal(8, 2)")]
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; } = String.Empty;
    }
}
