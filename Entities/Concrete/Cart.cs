using Core.Entities;

namespace Entities.Concrete
{
    public class Cart : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
    }
}
