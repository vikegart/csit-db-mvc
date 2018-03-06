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
    public class UserDAO : IUserData
    {
        private string connectString = SQLDALConfig.ConnectionString;

        public int AddUser(User user)
        {
            try
            {
                object idUser;
                using (var con = new SqlConnection(connectString))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddUser";
                    command.Parameters.AddWithValue("Name", user.Name);
                    command.Parameters.AddWithValue("Birthdate", user.Birthdate);
                    con.Open();
                    idUser = command.ExecuteScalar();
                }
                return Convert.ToInt32(idUser);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                using (var con = new SqlConnection(connectString))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteUser";
                    command.Parameters.AddWithValue("ID", id);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUserById(int idUser)
        {
            try
            {
                using (var con = new SqlConnection(connectString))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetUserById";
                    command.Parameters.AddWithValue("idUser", idUser);
                    con.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return ReadUser(reader);
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUserByName(string name)
        {


            System.Diagnostics.Debug.WriteLine(name);

            try
            {
                using (var con = new SqlConnection(connectString))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetUserByName";
                    command.Parameters.AddWithValue("name", name);
                    con.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return ReadUser(reader);
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<User> GetUsersByLetterName(string letterName)
        {
            using (var con = new SqlConnection(connectString))
            {
                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetUsersByLetterName";
                command.Parameters.AddWithValue("letterName", letterName + '%');
                con.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return ReadUser(reader);
                }
                con.Close();
            }
        }

        public IEnumerable<User> GetUsersByPartName(string partName)
        {
            using (var con = new SqlConnection(connectString))
            {
                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetUsersByPartName";
                command.Parameters.AddWithValue("partNameFirst", partName + '%');
                command.Parameters.AddWithValue("partNameEnd", '%' + partName);
                con.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return ReadUser(reader);
                }
                con.Close();
            }
        }

        public IEnumerable<User> GetUsers()
        {
            using (var con = new SqlConnection(connectString))
            {
                var command = new SqlCommand("SELECT u.id, u.name, u.Birthdate FROM dbo.Users u", con);
                con.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return ReadUser(reader);
                }
                con.Close();
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                using (var con = new SqlConnection(connectString))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateUser";
                    command.Parameters.AddWithValue("Name", user.Name);
                    command.Parameters.AddWithValue("Birthdate", user.Birthdate);
                    command.Parameters.AddWithValue("ID", user.ID);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private User ReadUser(SqlDataReader reader)
        {
            try
            {
                return new User
                {
                    ID = (int)reader["ID"],
                    Name = (string)reader["Name"],
                    Birthdate = (DateTime)reader["Birthdate"]
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
