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
        private readonly ApplicationDbContext _dbContext;
    
        public AdsService(ApplicationDbContext ctx)
        {
            _dbContext = ctx;
        }
        public Ad GetAdById(Guid id)
        {
            var result = _dbContext.Ads.FirstOrDefault(a => a.Id == id);
            return result;
        }

        public List<Ad> GetAdsByUserId(string id)
        {
            var result = _dbContext.Ads.Where(a => a.UserId == id).ToList();
            return result;
        }

        public void UpdateAdd(Ad ad)
        {
            var existingAd = GetAdById(ad.Id);
            existingAd.Copy(ad);
            _dbContext.SaveChanges();
        }

        public bool CreateAdAsync(Ad ad)
        {
            _dbContext.Ads.AddAsync(ad);
            var result = _dbContext.SaveChanges();
            return result != 0;
        }
    }
}
