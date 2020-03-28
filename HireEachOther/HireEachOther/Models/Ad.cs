using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HireEachOther.Models
{
    public class Ad
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [DisplayName("Give a nice title")]
        public string Title { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10)]
        [DisplayName("Describe shortly")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Willing to pay")]
        [Range(0.0, Double.MaxValue)]
        public double Payment { get; set; }

        [Range(1, 500)]
        [DisplayName("People needed")]
        public int PeopleNeeded { get; set; }

        [DisplayName("For how long")]
        public int Duration { get; set; }

        [DisplayName("When")]
        public DateTime StartDate { get; set; }

        [DisplayName("Where")]
        [StringLength(100, MinimumLength = 10)]
        public string Address { get; set; }

        public bool IsArchived { get; set; }

        public string UserId { get; set; }
        public User Owner { get; set; }
        public ICollection<Applicants> Applicants { get; set; }
    }
}
