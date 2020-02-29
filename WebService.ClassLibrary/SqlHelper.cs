using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebService.ClassLibrary
{
    public class SqlHelper
    {
        //insert
        //TAŞI VE SELECT PARAMETRE
        //select
        //update
        //truncate

        string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].
            ConnectionString;

        //SqlConnection connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString);

        public void InsertEntity(string title, string spot, string image, string link , int category,int orderofadding)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertEntites = ConfigurationModel.InsertEntites;
                SqlCommand cmd = new SqlCommand(insertEntites);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                Entities entities = new Entities();
                entities.CreatingDate = System.DateTime.Now;

                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Spot", spot);
                cmd.Parameters.AddWithValue("@Image", image);
                cmd.Parameters.AddWithValue("@Link", link ?? string.Empty);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@CreatingDate", entities.CreatingDate);
                cmd.Parameters.AddWithValue("@OrderOfAdding", orderofadding);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<Entities> SelectEntity(string select,string where)
        {
            
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            var strSelect = select + ConfigurationModel.SelectData + where;

            SqlCommand command = new SqlCommand(strSelect);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();

            List<Entities> entities = new List<Entities>();
            
            while (reader.Read())
            {
                var model = new Entities();

                model.Id = reader.GetInt32(0);
                model.Title = reader.GetString(1);
                model.Spot = reader.GetString(2);
                model.Image = reader.GetString(3);
                model.Link = reader.GetString(4) ?? string.Empty;
                model.Category = ((CategoryType)Convert.ToInt32(reader["Category"])).ToString();
                model.CreatingDate = reader.GetDateTime(5);
                model.OrderOfAdding = reader.GetInt32(6);

                entities.Add(model);
            }
            connection.Close();
            return entities;
        }

        public void TruncateEntity()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString);

            string s = ConfigurationModel.TruncateEntities;
            SqlCommand Com = new SqlCommand(s, con);
            con.Open();
            Com.ExecuteNonQuery();
        }

    }
}
