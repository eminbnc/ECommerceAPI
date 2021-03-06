namespace Entities.DTOs.Request
{
    public class ProductAddRequest
    {
        public int SubCategoryId { get; set; }
        public int StoreId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Technicality { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; }
    }
}



