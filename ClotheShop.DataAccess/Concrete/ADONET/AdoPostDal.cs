using ClotheShop.DataAccess.Abstract;
using ClotheShop.Entities.Concrete;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ClotheShop.DataAccess.Concrete.ADONET
{
    public class AdoPostDal : IPostDal
    {
        public void Add(Post entity)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Posts (Title,Details) " +
                 "VALUES(@Title,@Details)"))
            {
                cmd.Parameters.AddWithValue("Title", entity.Title);
                cmd.Parameters.AddWithValue("Details", entity.Details);
                VTYS.SqlExecuteNonQuery(cmd);
            }
        }

        public void Delete(Post entity)
        {
            using (SqlCommand cmd =
                 new SqlCommand("DELETE FROM Posts WHERE PostId = @PostId"))
            {
                cmd.Parameters.AddWithValue("PostId", entity.PostId);
                VTYS.SqlExecuteNonQuery(cmd);
            }
        }

        public Post Get(Expression<Func<Post, bool>> filter)
        {
            List<Post> postList = new List<Post>();
            SqlCommand cmd = new SqlCommand("Select * from Posts");

            SqlDataReader reader = VTYS.SqlExecuteReader(cmd);
            while (reader.Read())
            {
                Post post = new Post
                {
                    PostId = Convert.ToInt32(reader[0]),
                    Title = reader[1].ToString(),
                    Details = reader[2].ToString()
                };

                postList.Add(post);
            }
            var list = postList.Where(filter.Compile()).ToList();
            return list[0];
        }

        public List<Post> GetAll(Expression<Func<Post, bool>> filter = null)
        {
            List<Post> postList = new List<Post>();
            SqlCommand cmd = new SqlCommand("Select * from Posts");

            SqlDataReader reader = VTYS.SqlExecuteReader(cmd);
            while (reader.Read())
            {
                Post post = new Post
                {
                    PostId = Convert.ToInt32(reader[0]),
                    Title = reader[1].ToString(),
                    Details = reader[2].ToString()

                };

                postList.Add(post);
            }

            return filter == null ? postList : postList.Where(filter.Compile()).ToList();
        }

        public List<Post> GetFilter(Expression<Func<Post, bool>> filter)
        {
            List<Post> postList = new List<Post>();
            SqlCommand cmd = new SqlCommand("Select * from Posts");

            SqlDataReader reader = VTYS.SqlExecuteReader(cmd);
            while (reader.Read())
            {
                Post post = new Post
                {
                    PostId = Convert.ToInt32(reader[0]),
                    Title = reader[1].ToString(),
                    Details = reader[2].ToString()
                };

                postList.Add(post);
            }
            var list = postList.Where(filter.Compile()).ToList();
            return postList.Where(filter.Compile()).ToList(); ;
        }

        public void Update(Post entity)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE Posts set Title = @Title, Details=@Details WHERE PostId = @PostId"))
            {
                cmd.Parameters.AddWithValue("@PostId", entity.PostId);
                cmd.Parameters.AddWithValue("@Title", entity.Title);
                cmd.Parameters.AddWithValue("@Details", entity.Details);
                VTYS.SqlExecuteNonQuery(cmd);
            }
        }
    }
}
