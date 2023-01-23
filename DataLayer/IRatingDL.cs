namespace DataLayer
{
    public interface IRatingDL
    {
        void  insertRatingTable(string host, string method, string path, string referer, DateTime record_date);
    }
}