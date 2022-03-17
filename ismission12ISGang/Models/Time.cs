using System;
using System.ComponentModel.DataAnnotations;

namespace ismission12ISGang.Models
{
    public class Time
    {
        [Required]
        [Key]
        public int TimeID { get; set; }

        [Required]
        public string Month { get; set; }

        [Required]
        public int Day { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string TimeOfDay { get; set; }

    }
}
