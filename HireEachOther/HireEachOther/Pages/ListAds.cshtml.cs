using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HireEachOther.Models;
using HireEachOther.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HireEachOther.Pages
{
    public class ListAdsModel : PageModel
    {
        private readonly IAdsService _adsService;
        public ListAdsModel(IAdsService adsService)
        {
            _adsService = adsService;
        }

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; }
        public List<Ad> AdsToDisplay { get; set; }
        

        public void OnGet(bool? isNext = null)
        {
            if (isNext == null)
            {
                PageIndex = 1;
            }
            else
            {
                PageIndex = isNext.Value ? PageIndex + 1 : PageIndex - 1;
                if (PageIndex < 1)
                {
                    PageIndex = 1;
                }
            }

            AdsToDisplay = _adsService.GetAdsByPage(PageIndex);
            if (AdsToDisplay.Count == 0)
            {
                PageIndex = PageIndex > 1 ? --PageIndex : 1;
                AdsToDisplay = _adsService.GetAdsByPage(PageIndex);
            }
        }
    }
}
