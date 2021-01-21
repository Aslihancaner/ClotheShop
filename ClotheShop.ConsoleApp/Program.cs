using ClotheShop.Business.Abstract;
using ClotheShop.Business.CrossCuttingConcerns.DependencyResolvers.Ninject;
using ClotheShop.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ClotheShop.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var clotheService = InstanceFactory.Get<IClotheService>();          
            clotheService.GetAll().ForEach(x => Console.WriteLine(x));
           
            var postService = InstanceFactory.Get<IPostService>();          
            postService.GetAll().ForEach(x => Console.WriteLine(x));
                   
            Console.ReadKey();
           
        }
    }
}
