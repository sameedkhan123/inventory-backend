namespace InventroyManagement.Models.DTO
{
    public class PurchaseWithNamesDto
    {
        public int PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
    }
}
