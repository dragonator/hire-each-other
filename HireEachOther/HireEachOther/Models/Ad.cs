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
        public Ad()
        {
            Id = Guid.NewGuid();
            Applicants = new HashSet<Applicants>();
            Comments = new HashSet<AdComment>();
            IsArchived = false;
            StartDate = DateTime.Now;
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [DisplayName("Give a nice title")]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
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

        [Required]
        [DisplayName("Where")]
        [StringLength(100, MinimumLength = 10)]
        public string Address { get; set; }
        public bool IsArchived { get; set; }
        public string UserId { get; set; }
        public User Owner { get; set; }

        public AdType Type { get;set; }
        public ICollection<Applicants> Applicants { get; set; }
        public ICollection<AdComment> Comments { get; set; }


        public void Copy(Ad update)
        {
            this.Title = update.Title;
            this.Description = update.Description;
            this.Payment = update.Payment;
            this.PeopleNeeded = update.PeopleNeeded;
            this.Duration = update.Duration;
            this.StartDate = update.StartDate;
            this.Address = update.Address;
        }
    }
}
