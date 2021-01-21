using ClotheShop.Business.Abstract;
using ClotheShop.DataAccess.Abstract;
using ClotheShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ClotheShop.Business.Concrete
{
    public class PostManager : IPostService
    {
        private IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public void Add(Post entity)
        {
            _postDal.Add(entity);
        }

        public void Delete(Post entity)
        {
            _postDal.Delete(entity);
        }

        public Post Get(Expression<Func<Post, bool>> filter)
        {
            return _postDal.Get(filter);
        }

        public List<Post> GetAll(Expression<Func<Post, bool>> filter = null)
        {
            return _postDal.GetAll(filter);
        }

        public List<Post> GetFilter(Expression<Func<Post, bool>> filter)
        {
            return _postDal.GetFilter(filter);
        }

        public void Update(Post entity)
        {
            _postDal.Update(entity);
        }
    }
}
