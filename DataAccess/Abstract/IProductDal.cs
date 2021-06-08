using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        Task<List<GetProductQueryResponse>> GetProductsByCategoryWithSubCategory(int categoryId, int subCategoryId);
        Task<List<GetProductQueryResponse>> GetProductsByCategoryId(int categoryId);
    }
}
