using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commands.ProductCommands
{
    public class ProductDeleteCommand:IRequest<IResult>
    {
        public int ProductId { get; set; }
        public ProductDeleteCommand(int productId)
        {
            ProductId = productId;
        }
    }
}
