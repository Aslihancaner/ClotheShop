using ClotheShop.DataAccess.Abstract;
using ClotheShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClotheShop.DataAccess.Concrete.EntityFramework
{
  public class EfPostDal : EfRepositoryBase<Post, ClotheShopContext>, IPostDal
    {
    }
}
