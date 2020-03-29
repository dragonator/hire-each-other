using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HireEachOther.Data;
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
        private readonly ApplicationDbContext _dbContext;

        public AdProfileModel(IAdsService adsService
                        , ICommentsService commentService
                        ,IHttpContextAccessor httpContextAccessor
                        ,UserManager<User> userManager
                        ,ApplicationDbContext dbContext)
        {
            _adsService = adsService;
            _commentService = commentService;
            _httpContext = httpContextAccessor;
            _userService = userManager;
            _dbContext = dbContext;
        }

        public Ad Ad { get; set; }

        [BindProperty]
        public AdComment Comment { get; set; }

        public void OnGet(string adId)
        {
            var AdId = Guid.Parse(adId);
            Ad = _adsService.GetAdById(AdId);
            Ad.Comments = Ad.Comments.OrderByDescending(a => a.DateAdded).ToList();
            var identityClaim = _httpContext.HttpContext.User;
            var user = _userService.GetUserAsync(identityClaim).Result;
            ViewData["AlreadyApplied"] = _dbContext.Applicants
                .Any(ap => ap.UserId == user.Id && ap.AdId == AdId);
            ViewData["UserOwnsTheAd"] = Ad.Owner.Id == user.Id;
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

        public IActionResult OnPostApply(string adId)
        {
            var AdId = Guid.Parse(adId);
            var identityClaim = _httpContext.HttpContext.User;
            var user = _userService.GetUserAsync(identityClaim).Result;

            _dbContext.Applicants.Add(new Applicants()
            {
                UserId = user.Id,
                AdId = AdId
            });

            _dbContext.SaveChanges();

            //Comment.UserId = user.Id;
            //Comment.DateAdded = DateTime.Now;
            //_commentService.AddCommentToAd(Comment);


            return RedirectToPage("AdProfile", new { adId = AdId });
        }
    }
}