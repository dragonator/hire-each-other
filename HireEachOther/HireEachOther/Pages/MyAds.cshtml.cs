using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HireEachOther.Models;
using HireEachOther.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HireEachOther.Pages
{
    public class MyAdsModel : PageModel
    {
        private readonly IAdsService _adsService;
        private readonly UserManager<User> _userService;
        private readonly IHttpContextAccessor _httpContextr;

        public MyAdsModel(IAdsService adsService,
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager)
        {
            _adsService = adsService;
            _userService = userManager;
            _httpContextr = httpContextAccessor;
        }

        public List<Ad> AdsCollection { get; set; }

        public void OnGet()
        {
            
            var identityClaim = _httpContextr.HttpContext.User;
            var user = _userService.GetUserId(identityClaim);
            AdsCollection = _adsService.GetAdsByUserId(user);


        }
    }
}