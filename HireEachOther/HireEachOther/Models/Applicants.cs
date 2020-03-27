using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HireEachOther.Models
{
    public class Applicants
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public Guid AdId { get; set; }
        public Ad Ad { get; set; }

        public ApplicationStatus Status { get; set; }
    }
}
