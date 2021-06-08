using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, ECommerceContext>, ICategoryDal
    {
        public async Task<List<CategoriesWithSubCategoriesResponse>> GetCategoriesWithSubCategory()
        {
            await using (ECommerceContext context = new ECommerceContext())
            {
                var response = from c in context.Categories
                               join
                               s in context.SubCategories on
                               c.Id equals s.CategoryId
                               select new CategoriesWithSubCategoriesResponse
                               {
                                   CategoryId = c.Id,
                                   SubCategoryId = s.Id,
                                   CategoryName = c.CategoryName,
                                   SubCategoryName = s.SubCategoryName
                               };
                return response.ToList();
            }
        }
    }
}
