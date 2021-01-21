using ClotheShop.Business.Abstract;
using ClotheShop.DataAccess.Abstract;
using ClotheShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ClotheShop.Business.Concrete
{
    public class ClotheManager : IClotheService
    {
        private IClotheDal _clothe;

        public ClotheManager(IClotheDal clothe)
        {
            _clothe = clothe;
        }

        public void Add(Clothe entity)
        {
            _clothe.Add(entity);
        }

        public void Delete(Clothe entity)
        {
            _clothe.Delete(entity);
        }

        public Clothe Get(Expression<Func<Clothe, bool>> filter)
        {
            return _clothe.Get(filter);
        }

        public List<Clothe> GetAll(Expression<Func<Clothe, bool>> filter = null)
        {
            return _clothe.GetAll(filter);
        }

        public List<Clothe> GetFilter(Expression<Func<Clothe, bool>> filter)
        {
            return _clothe.GetFilter(filter);
        }

        public void Update(Clothe entity)
        {
            _clothe.Update(entity);
        }
    }
}
