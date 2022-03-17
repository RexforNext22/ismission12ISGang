using System;
using System.ComponentModel.DataAnnotations;

namespace ismission12ISGang.Models
{
    public class Person
    {
        // set up Person model in the database
        [Key]
        [Required]
        public int PersonID { get; set; }

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
