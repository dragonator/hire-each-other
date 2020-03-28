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
    public class AdProfileModel : PageModel
    {
        private readonly IAdsService _adsService;
        private readonly ICommentsService _commentService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<User> _userService;

        public AdProfileModel(IAdsService adsService
            ,ICommentsService commentService,
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager)
        {
            _adsService = adsService;
            _commentService = commentService;
            _httpContext = httpContextAccessor;
            _userService = userManager;
        }

        public Ad Ad { get; set; }
        
        [BindProperty]
        public AdComment Comment { get; set; }

        public void OnGet(string adId)
        {
            Ad = _adsService.GetAdById(Guid.Parse(adId));
            Ad.Comments = Ad.Comments.OrderBy(a => a.DateAdded).ToList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //Comment.TargetId = Ad.Id;
                var identityClaim = _httpContext.HttpContext.User;
                var user = _userService.GetUserAsync(identityClaim).Result;
                Comment.UserId = user.Id;
                Comment.DateAdded = DateTime.Now;
                _commentService.AddCommentToAd(Comment);
                
            }
            return RedirectToPage("AdProfile", new { adId = Comment.TargetId });
        }
    }
}