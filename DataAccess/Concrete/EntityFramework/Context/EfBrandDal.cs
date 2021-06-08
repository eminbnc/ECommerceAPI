using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class EfBrandDal:EfEntityRepositoryBase<Brand,ECommerceContext>,IBrandDal
    {
    }
}
