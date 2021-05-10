﻿namespace Entities.DTOs.Response
{
    public class GetItemsInCartResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int InStock { get; set; }
    }
}
