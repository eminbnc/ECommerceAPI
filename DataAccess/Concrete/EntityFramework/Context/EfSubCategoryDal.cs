using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class EfSubCategoryDal:EfEntityRepositoryBase<SubCategory,ECommerceContext>,ISubCategoryDal
    {
    }
}
