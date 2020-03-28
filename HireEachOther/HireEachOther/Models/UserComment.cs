using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HireEachOther.Models
{
    public class UserComment
    {
        public UserComment()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Comment { get; set; }


        public DateTime DateAdded { get; set; }


        public string TargetId { get; set; }
        public User Target { get; set; }

        public string UserId { get; set; }
        public User Owner { get; set; }
    }
}
