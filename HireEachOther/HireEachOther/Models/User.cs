using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HireEachOther.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            OwnedAds = new HashSet<Ad>();
            Applications = new HashSet<Applicants>();
            Comments = new HashSet<UserComment>();
            Rating = 1.0f;
        }
        [Range(1.0f, 5.0f)]
        public float Rating { get; set; }

        public ICollection<Ad> OwnedAds { get; set; }
        public ICollection<Applicants> Applications { get; set; }
        public ICollection<UserComment> Comments { get; set; }
    }
}
