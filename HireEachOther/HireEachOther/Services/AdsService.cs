using HireEachOther.Data;
using HireEachOther.Models;
using HireEachOther.Services.Contracts;
using Microsoft.EntityFrameworkCore;
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
            var result = _dbContext.Ads
                .Include(a => a.Comments)
                .ThenInclude(c => c.Owner)
                .FirstOrDefault(a => a.Id == id);
            return result;
        }

        public List<Ad> GetAdsByPage(int index)
        {
            var result = _dbContext.Ads.Skip(10 * (index - 1)).Take(10).Include(a => a.Comments).ToList();
            return result;
        }

        public List<Ad> GetAdsByUserId(string id)
        {
            var result = _dbContext.Ads.Where(a => a.UserId == id).Include(a => a.Comments).ToList();
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
