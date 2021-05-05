using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICartDal:IEntityRepository<Cart>
    {
        Task<List<GetItemsInCartResponse>> GetItemsInBasket(int userId);
    }
}
