using Entities;

namespace BusinessLayer
{
    public interface IRatingBL
    {
        Task InsertRatingTable(string host, string method, string path, string Referer, string UserAgent, DateTime record_date);
       
    }
}