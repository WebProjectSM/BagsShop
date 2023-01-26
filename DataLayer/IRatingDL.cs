using System;

namespace DataLayer
{
    public interface IRatingDL
    {
        void  insertRatingTable(string host, string method, string path, DateTime record_date);
    }
}