using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HireEachOther.Models
{
    public class AdComment
    {
        public AdComment()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [StringLength(500, MinimumLength = 1)]
        public string Comment { get; set; }

        public DateTime DateAdded { get; set; }

        public Guid TargetId { get; set; }
        public Ad Target { get; set; }

        public string UserId { get; set; }
        public User Owner { get; set; }
    }
}
