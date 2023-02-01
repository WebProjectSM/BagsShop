using System;

namespace DataLayer
{
    public interface IRatingDL
    {
         Task  InsertRatingTable(string host, string method, string path, string Referer, string UserAgent, DateTime record_date);
    }
}