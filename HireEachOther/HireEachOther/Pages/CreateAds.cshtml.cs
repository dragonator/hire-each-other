using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HireEachOther.Models;
using HireEachOther.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HireEachOther.Pages
{
    [Authorize]
    public class CreateAdsModel : PageModel
    {
        private readonly IAdsService _adsService;
        public CreateAdsModel(IAdsService adsService)
        {
            _adsService = adsService;
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