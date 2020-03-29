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
    public class UserProfileModel : PageModel
    {
        private readonly UserManager<User> _userService;
        private readonly ICommentsService _commentService;
        private readonly IHttpContextAccessor _httpContext;
        public UserProfileModel(UserManager<User> userManager
            ,ICommentsService commentService
            ,IHttpContextAccessor httpContextr)
        {
            _userService = userManager;
            _commentService = commentService;
            _httpContext = httpContextr;
        }

        [BindProperty]
        public UserComment Comment { get; set; }
        public User SelectedUser { get; set; }
        public string UserFullName { get; set; }

        public void OnGet(string userId)
        {
            SelectedUser = _userService.Users
                .FirstOrDefault(u => u.Id == userId);
            SelectedUser.Comments = _commentService.GetUserComments(SelectedUser.Id);
            UserFullName = HackyUsername(SelectedUser.Email);
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
                _commentService.AddCommentToUser(Comment);

            }
            return RedirectToPage("UserProfile", new { userId = Comment.TargetId });
        }


        private string HackyUsername(string username)
        {
            var fullName = username.Split("@")[0].Split(".");
            var firstName = fullName[0].First().ToString().ToUpper() + fullName[0].Substring(1);
            var lastName = fullName[1].First().ToString().ToUpper() + fullName[1].Substring(1);
            return firstName + " " + lastName;
        }
    }
}