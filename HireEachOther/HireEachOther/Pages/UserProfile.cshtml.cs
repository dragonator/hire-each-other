using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HireEachOther.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HireEachOther.Pages
{
    public class UserProfileModel : PageModel
    {
        private readonly UserManager<User> _userService;
        public UserProfileModel(UserManager<User> userManager)
        {
            _userService = userManager;
        }

        public User SelectedUser { get; set; }
        public void OnGet(string userId)
        {
            SelectedUser = _userService.Users.FirstOrDefault(u => u.Id == userId);
        }
    }
}