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
        }

        [BindProperty]
        public Ad Ad { get; set; }

        public void OnGet()
        {
            Ad = new Ad();
            if (!TempData.ContainsKey("RequestType"))
            {
                TempData["RequestType"] = "Create new ad";
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var dbAd = _adsService.GetAdById(Ad.Id);
                if (dbAd == null)  // create new
                {
                    //get current user
                    var identityClaim = _httpContextr.HttpContext.User;
                    var user = _userService.GetUserAsync(identityClaim).Result;
                    Ad.Owner = user;
                    var success = _adsService.CreateAdAsync(Ad);
                    return Redirect("MyAds");
                    //todo: add success message
                }
                else // update
                {
                    _adsService.UpdateAdd(Ad);
                    //todo: add success message

                    return Redirect("Index");
                }
            }

            return Page();

        }
    }
}