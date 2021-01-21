using ClotheShop.Business.Abstract;
using ClotheShop.Business.Concrete;
using ClotheShop.DataAccess.Abstract;
using ClotheShop.DataAccess.Concrete.ADONET;
using ClotheShop.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClotheShop.Business.CrossCuttingConcerns.DependencyResolvers.Ninject
{
    public class BusinessModüle : NinjectModule
    {
        public override void Load()
        {
            Bind<IClotheService>().To<ClotheManager>().InSingletonScope();
           // Bind<IClotheDal>().To<EfClotheDal>().InSingletonScope();
            Bind<IClotheDal>().To<AdoClotheDal>().InSingletonScope();

            Bind<IPostService>().To<PostManager>().InSingletonScope();
            // Bind<IPostDal>().To<AdoPostDal>().InSingletonScope();
            Bind<IPostDal>().To<EfPostDal>().InSingletonScope();
        }
    }
}
