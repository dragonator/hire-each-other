using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HireEachOther.Models;
using HireEachOther.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HireEachOther.Pages
{
    [Authorize]
    public class CreateAdsModel : PageModel
    {
        private readonly IAdsService _adsService;
        private readonly UserManager<User> _userService;
        private readonly IHttpContextAccessor _httpContextr;


        public CreateAdsModel(IAdsService adsService,
            IHttpContextAccessor httpContextAccessor, 
            UserManager<User> userManager)
        {
            _adsService = adsService;
            _userService = userManager;
            _httpContextr = httpContextAccessor;
            //var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var userIddd = httpContextAccessor.HttpContext.User/*.FindFirst(ClaimTypes.NameIdentifier).Value*/;
            //var us = userManager.GetUserAsync(httpContextAccessor.HttpContext.User);

        }
        [BindProperty]
        public Ad Ad { get; set; }

        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            _adsService.CreateAd(Ad);
        }
    }
}