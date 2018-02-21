using Entities;
using IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AwardImageDAO : IAwardImageData
    {
        private string connectString = SQLDALConfig.ConnectionString;

        public void AddAwardImage(Image image)
        {
            try
            {
                using (var con = new SqlConnection(connectString))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddAwardImage";
                    command.Parameters.AddWithValue("Name", image.Name);
                    command.Parameters.AddWithValue("Byte", image.Byte);
                    command.Parameters.AddWithValue("Type", image.Type);
                    command.Parameters.AddWithValue("idAward", image.Id_Owner);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAwardImage(int idAward)
        {
            try
            {
                using (var con = new SqlConnection(connectString))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteAwardImage";
                    command.Parameters.AddWithValue("idAward", idAward);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Image GetImageByAward(int idAward)
        {
            try
            {
                using (var con = new SqlConnection(connectString))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetImageByAward";
                    command.Parameters.AddWithValue("idAward", idAward);
                    con.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return ReadImage(reader);
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(int idAward, Image newImage)
        {
            try
            {
                DeleteAwardImage(idAward);
                newImage.Id_Owner = idAward;
                AddAwardImage(newImage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Image ReadImage(SqlDataReader reader)
        {
            try
            {
                return new Image
                {
                    Id = (int)reader["ID"],
                    Name = (string)reader["Name"],
                    Byte = (byte[])reader["Byte"],
                    Type = (string)reader["Type"],
                    Id_Owner = (int)reader["id_award"]
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
