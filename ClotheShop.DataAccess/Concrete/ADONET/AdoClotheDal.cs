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
    public class AdoClotheDal : IClotheDal
    {
        public void Add(Clothe entity)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Clothes (Name,UnitPrice) " +
                "VALUES(@Name,@UnitPrice)"))
            {
                cmd.Parameters.AddWithValue("Name", entity.Name);
                cmd.Parameters.AddWithValue("UnitPrice", entity.UnitPrice);
                VTYS.SqlExecuteNonQuery(cmd);
            }
        }

        public void Delete(Clothe entity)
        {
            using (SqlCommand cmd =
                new SqlCommand("DELETE FROM Clothes WHERE ClotheId = @ClotheId"))
            {
                cmd.Parameters.AddWithValue("ClotheId", entity.ClotheId);
                VTYS.SqlExecuteNonQuery(cmd);
            }
        }

        public Clothe Get(Expression<Func<Clothe, bool>> filter)
        {
            List<Clothe> clotheList = new List<Clothe>();
            SqlCommand cmd = new SqlCommand("Select * from Clothes");

            SqlDataReader reader = VTYS.SqlExecuteReader(cmd);
            while (reader.Read())
            {
                Clothe clothe = new Clothe
                {
                    ClotheId = Convert.ToInt32(reader[0]),
                    Name = reader[1].ToString(),
                    UnitPrice = Convert.ToDecimal(reader[2])                
                };

                clotheList.Add(clothe);
            }
            var list = clotheList.Where(filter.Compile()).ToList();
            return list[0];
        }

        public List<Clothe> GetAll(Expression<Func<Clothe, bool>> filter = null)
        {

            List<Clothe> clotheList = new List<Clothe>();
            SqlCommand cmd = new SqlCommand("Select * from Clothes");

            SqlDataReader reader = VTYS.SqlExecuteReader(cmd);
            while (reader.Read())
            {
                Clothe clothe = new Clothe
                {
                    ClotheId = Convert.ToInt32(reader[0]),
                    Name = reader[1].ToString(),
                    UnitPrice = Convert.ToDecimal(reader[2])
                  
                };

                clotheList.Add(clothe);
            }

            return filter == null ? clotheList : clotheList.Where(filter.Compile()).ToList();


        }

        public List<Clothe> GetFilter(Expression<Func<Clothe, bool>> filter)
        {
            List<Clothe> clotheList = new List<Clothe>();
            SqlCommand cmd = new SqlCommand("Select * from Clothes");

            SqlDataReader reader = VTYS.SqlExecuteReader(cmd);
            while (reader.Read())
            {
                Clothe clothe = new Clothe
                {
                    ClotheId = Convert.ToInt32(reader[0]),
                    Name = reader[1].ToString(),                
                    UnitPrice = Convert.ToDecimal(reader[2].ToString())
                };

                clotheList.Add(clothe);
            }
            var list = clotheList.Where(filter.Compile()).ToList();
            return clotheList.Where(filter.Compile()).ToList(); ;
        }

        public void Update(Clothe entity)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE Clothes set Name = @Name, UnitPrice=@UnitPrice WHERE ClotheId = @ClotheId"))
            {
                cmd.Parameters.AddWithValue("@ClotheId", entity.ClotheId);
                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@UnitPrice", entity.UnitPrice);
                VTYS.SqlExecuteNonQuery(cmd);
            }
        }
    }
}
