using System;

namespace DataLayer
{
    public interface IRatingDL
    {
         Task  InsertRatingTable(string host, string method, string path, DateTime record_date);
    }
}