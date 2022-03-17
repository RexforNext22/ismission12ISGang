using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


        //[ForeignKey("Person")]
        public int? PersonID { get; set; }
        public Person Person { get; set; }

        [Required]
        public bool bReserved { get; set; }

    }
}
