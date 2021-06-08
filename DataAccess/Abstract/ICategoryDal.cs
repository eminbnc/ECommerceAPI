﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public  interface ICategoryDal:IEntityRepository<Category>
    {
        Task<List<CategoriesWithSubCategoriesResponse>> GetCategoriesWithSubCategory();
    }
}
