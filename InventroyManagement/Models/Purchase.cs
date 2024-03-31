using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventroyManagement.Models
{
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseId { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        // Foreign key property for Product
        public int ProductId { get; set; }

        // Navigation property for Product
        public virtual Product Product { get; set; }

        // Foreign key property for Supplier
        public int SupplierId { get; set; }

        // Navigation property for Supplier
        public virtual Supplier Supplier { get; set; }
    }
}