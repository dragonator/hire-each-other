using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HireEachOther.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HireEachOther.Pages
{
    [Authorize]
    public class CreateAdsModel : PageModel
    {
        public Ad Ad { get; set; }
        public void OnGet()
        {

        }
    }
}