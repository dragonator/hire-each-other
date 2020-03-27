using System;
using System.Collections.Generic;
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
        public string Title { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        [Range(0.0, Double.MaxValue)]
        public double Payment { get; set; }

        public DateTime StartDate { get; set; }
    }
}
