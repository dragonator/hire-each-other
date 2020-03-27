using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HireEachOther.Pages
{
    [Authorize]
    public class CreateAdsModel : PageModel
    {
        public string Ad { get; set; }
        public void OnGet()
        {

        }
    }
}