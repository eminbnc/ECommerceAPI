namespace Entities.DTOs.Request
{
    public class AddProductToCartRequest
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
