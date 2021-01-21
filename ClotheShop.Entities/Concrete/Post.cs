using ClotheShop.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClotheShop.Entities.Concrete
{
   public class Post : IEntity
    {

        public int PostId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public Post()
        {

        }

        public Post(int postId, string title, string details)
        {
            PostId = postId;
            Title = title;
            Details = details;
        }
        public override string ToString()
        {
            return $"{PostId,-5}{Title,-5}{Details,-5}";
        }
    }
}
