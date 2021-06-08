using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Response
{
   public  class GetAllCategoryQueryResponse
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
