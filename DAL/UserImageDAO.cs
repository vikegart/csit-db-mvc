﻿using Entities;
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
    public class UserImageDAO : IUserImageData
    {
        private string connectString = SQLDALConfig.ConnectionString;

        public void AddUserImage(Image image)
        {
            try
            {
                using (var con = new SqlConnection(connectString))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddUserImage";
                    command.Parameters.AddWithValue("Name", image.Name);
                    command.Parameters.AddWithValue("Byte", image.Byte);
                    command.Parameters.AddWithValue("Type", image.Type);
                    command.Parameters.AddWithValue("idUser", image.Id_Owner);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteUserImage(int idUser)
        {
            try
            {
                using (var con = new SqlConnection(connectString))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteUserImage";
                    command.Parameters.AddWithValue("idUser", idUser);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Image GetImageByUser(int idUser)
        {
            try
            {
                using (var con = new SqlConnection(connectString))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetImageByUser";
                    command.Parameters.AddWithValue("idUser", idUser);
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

        public void Update(int idUser, Image newImage)
        {
            try
            {
                DeleteUserImage(idUser);
                newImage.Id_Owner = idUser;
                AddUserImage(newImage);
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
                    Id_Owner = (int)reader["id_user"]
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
