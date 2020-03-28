using HireEachOther.Data;
using HireEachOther.Models;
using HireEachOther.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HireEachOther.Services
{
    public class AdsService : IAdsService
    {
        private ApplicationDbContext _dbContext;
        public AdsService(ApplicationDbContext ctx)
        {
            _dbContext = ctx;
        }
        public Ad GetAdById(string id)
        {
            var result = _dbContext.Ads.FirstOrDefault(a => a.Id.ToString() == id);
            return result;
        }

        public bool CreateAd(Ad ad)
        {
            _dbContext.Ads.Add(ad);
            var result = _dbContext.SaveChanges();
            return result != 0;
        }
    }
}
