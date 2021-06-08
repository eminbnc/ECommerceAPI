using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class EfCartDal : EfEntityRepositoryBase<Cart, ECommerceContext>, ICartDal
    {
        public async Task<List<GetItemsInCartResponse>> GetItemsInBasket(int userId)
        {
           await using (ECommerceContext context = new ECommerceContext())
            {
                var result = from p in context.Products
                             join c in context.Carts
                                 on p.Id equals c.ProductId
                             where (c.UserId == userId)
                             select new GetItemsInCartResponse
                             {
                                 Id = c.Id,
                                 ProductId = p.Id,
                                 ProductImage = p.ImagePath,
                                 UnitPrice = p.UnitPrice,
                                 Quantity = c.Quantity,
                                 ProductName = p.ProductName,
                                 InStock = p.Stock
                             };
                return result.ToList();
            }
        }
    }
}
