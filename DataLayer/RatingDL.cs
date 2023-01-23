using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class RatingDL : IRatingDL
    {
        public readonly IConfiguration _configuration;
        public RatingDL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void insertRatingTable(string host, string method, string path, string referer, DateTime record_date)
        {
            string query = "INSERT INTO [dbo].[bags_details] ([HOST],[METHOD],[PATH],[REFERER],[RECORD_DATE]) VALUES(@host,@method,@path,@referer,@record_date)";
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("school")))
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlCommand.Parameters.Add("@HOST", SqlDbType.NVarChar).Value = host;
                sqlCommand.Parameters.Add("@METHOD", SqlDbType.NVarChar).Value = method;
                sqlCommand.Parameters.Add("@PATH", SqlDbType.NVarChar).Value = path;
                sqlCommand.Parameters.Add("@REFERER", SqlDbType.NVarChar).Value = referer;
                sqlCommand.Parameters.Add("@RECORD_DATE", SqlDbType.Date).Value = record_date;



                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }





        }
    }
}

