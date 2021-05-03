using Core.Entities;

namespace Entities.Concrete
{
    public class SubCategory : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
