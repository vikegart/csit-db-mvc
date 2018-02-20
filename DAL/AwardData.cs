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
    public class AwardData : IAwardData
    {
        private string connectString = SQLDALConfig.ConnectionString;

        private static Award ReadAward(SqlDataReader reader)
        {
            try
            {
                return new Award
                {
                    ID = (int)reader["ID"],
                    Title = (string)reader["Title"],
                    Description = (string)reader["Description"]
                };
            }
            catch
            {
                throw new ArgumentException("ReadAward");
            }
        }
        public int AddAward(Award award)
        {
            try
            {
                object idAward;
                using (var con = new SqlConnection(connectString))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddAward";
                    command.Parameters.AddWithValue("Title", award.Title);
                    command.Parameters.AddWithValue("Description", award.Description ?? "");
                    con.Open();
                    idAward = command.ExecuteScalar();
                }
                return Convert.ToInt32(idAward);
            }
            catch
            {
                throw new ArgumentException("AddAward");
            }
        }

        public void CancelAwardToUser(int idUser, int idAward)
        {
            try
            {
                using (var con = new SqlConnection(connectString))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "CancelAwardToUser";
                    command.Parameters.AddWithValue("idAward", idAward);
                    command.Parameters.AddWithValue("idUser", idUser);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new ArgumentException("AddAward");
            }
        }

        public void DeleteAward(int id)
        {
            try
            {
                using (var con = new SqlConnection(connectString))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteAward";
                    command.Parameters.AddWithValue("ID", id);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new ArgumentException("DeleteAward");
            }
        }

        public Award GetAwardById(int idAward)
        {
            try
            {
                using (var con = new SqlConnection(connectString))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetAwardById";
                    command.Parameters.AddWithValue("idAward", idAward);
                    con.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return ReadAward(reader);
                    }
                    return null;
                }
            }
            catch
            {
                throw new ArgumentException("GetAwardById");
            }
        }

        public IEnumerable<Award> GetAwardByLetterName(string letterName)
        {
            using (var con = new SqlConnection(connectString))
            {
                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAwardByLetterName";
                command.Parameters.AddWithValue("letterName", letterName + '%');
                con.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return ReadAward(reader);
                }
                con.Close();
            }
        }

        public Award GetAwardByName(string name)
        {
            try
            {
                using (var con = new SqlConnection(connectString))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetAwardByName";
                    command.Parameters.AddWithValue("name", name);
                    con.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return ReadAward(reader);
                    }
                    return null;
                }
            }
            catch
            {
                throw new ArgumentException("GetAwardByName");
            }
        }

        public IEnumerable<Award> GetAwardByPartName(string partName)
        {
            using (var con = new SqlConnection(connectString))
            {
                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAwardByPartName";
                command.Parameters.AddWithValue("partName", '%' + partName + '%');
                con.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return ReadAward(reader);
                }
                con.Close();
            }
        }

        public IEnumerable<Award> GetAwards()
        {
            using (var con = new SqlConnection(connectString))
            {
                var command = new SqlCommand("SELECT a.id, a.Title, a.Description FROM dbo.Awards a", con);
                con.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return ReadAward(reader);
                }
                con.Close();
            }
        }

        public IEnumerable<Award> GetAwardsByUser(int idUser)
        {
            using (var con = new SqlConnection(connectString))
            {
                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAwardsByUser";
                command.Parameters.AddWithValue("idUser", idUser);
                con.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return ReadAward(reader);
                }
                con.Close();
            }
        }

        public IEnumerable<Award> GetFreeAwards(int idUser)
        {
            using (var con = new SqlConnection(connectString))
            {
                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetFreeAwards";
                command.Parameters.AddWithValue("idUser", idUser);
                con.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return ReadAward(reader);
                }
                con.Close();
            }
        }

        public void SetAwardToUser(int idUser, int idAward)
        {
            try
            {
                using (var con = new SqlConnection(connectString))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SetAwardToUser";
                    command.Parameters.AddWithValue("idUser", idUser);
                    command.Parameters.AddWithValue("idAward", idAward);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new ArgumentException("SetAwardToUser");
            }
        }

        public void UpdateAward(Award award)
        {
            try
            {
                using (var con = new SqlConnection(connectString))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateAward";
                    command.Parameters.AddWithValue("Title", award.Title);
                    command.Parameters.AddWithValue("Description", award.Description ?? "");
                    command.Parameters.AddWithValue("ID", award.ID);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new ArgumentException("UpdateAward");
            }
        }
    }
}
