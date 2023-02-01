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
        public async Task InsertRatingTable(string host, string method, string path ,string Referer, string UserAgent , DateTime record_date)
        {
            string query = "INSERT INTO [RATING] ([HOST],[METHOD],[PATH],[REFERER],[USER_AGENT],[RECORD_DATE]) VALUES(@host,@method,@path,@Referer,@UserAgent,@record_date)";
            using ( SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("school")))
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlCommand.Parameters.Add("@HOST", SqlDbType.NVarChar).Value = host;
                sqlCommand.Parameters.Add("@METHOD", SqlDbType.NVarChar).Value = method;
                sqlCommand.Parameters.Add("@PATH", SqlDbType.NVarChar).Value = path;
                sqlCommand.Parameters.Add("@RECORD_DATE", SqlDbType.DateTime).Value = record_date;
                sqlCommand.Parameters.Add("@REFERER", SqlDbType.NVarChar).Value =Referer;
                sqlCommand.Parameters.Add("@USERAGENT", SqlDbType.NVarChar).Value = UserAgent;

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }

        }
    }
}

