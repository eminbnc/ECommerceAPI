using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Entities.DTOs.Response;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ECommerceContext>, IProductDal
    {
        public async Task<List<GetProductQueryResponse>> GetProductsByCategoryWithSubCategory(int categoryId, int subCategoryId)
        {
            using (ECommerceContext context = new ECommerceContext())
            {
                var response = from s in context.SubCategories
                               join p in context.Products on s.Id equals p.SubCategoryId
                               where s.CategoryId == categoryId
                               where s.Id == subCategoryId
                               select new GetProductQueryResponse
                               {
                                   Id = p.Id,
                                   Brand = p.Brand,
                                   Description = p.Description,
                                   Discount = p.Discount,
                                   ImagePath = p.ImagePath,
                                   Stock = p.Stock,
                                   StoreId = p.StoreId,
                                   ProductName = p.ProductName,
                                   SubCategoryId = p.SubCategoryId,
                                   Model = p.Model,
                                   Tax = p.Tax,
                                   Technicality = p.Technicality,
                                   UnitPrice = p.UnitPrice
                               };
                return response.ToList();
            }
        }
    }
}
