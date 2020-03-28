using HireEachOther.Data;
using HireEachOther.Models;
using HireEachOther.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HireEachOther.Services
{
    public class AdsService : IAdsService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userService;
        private readonly IHttpContextAccessor _httpContextr;

        public AdsService(ApplicationDbContext ctx, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _dbContext = ctx;
            _userService = userManager;
            _httpContextr = httpContextAccessor;
            //var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var userIddd = httpContextAccessor.HttpContext.User/*.FindFirst(ClaimTypes.NameIdentifier).Value*/;
            //var us = userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
           
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
