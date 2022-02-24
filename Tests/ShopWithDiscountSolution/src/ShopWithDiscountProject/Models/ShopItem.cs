using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWithDiscountProject.Models
{
    public class ShopItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    }
}
