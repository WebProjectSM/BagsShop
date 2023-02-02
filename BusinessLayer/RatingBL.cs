using DataLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class RatingBL : IRatingBL
    {
        readonly IRatingDL _dl;
        public RatingBL(IRatingDL IRatingDL)
        {
            _dl = IRatingDL;
        }
        public async Task InsertRatingTable(string host, string method, string path, string Referer, string UserAgent, DateTime record_date)
        {
            await _dl.InsertRatingTable(host, method, path, Referer, UserAgent, DateTime.Now);
        }
    }
}
