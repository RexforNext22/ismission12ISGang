using System;
using System.ComponentModel.DataAnnotations;

namespace ismission12ISGang.Models
{
    public class Person
    {
        [Key]
        [Required]
        public int PersonID { get; set; }

        [Required]
        public int TimeID { get; set; }
        public Time Time { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1,15)]
        public int Size { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
