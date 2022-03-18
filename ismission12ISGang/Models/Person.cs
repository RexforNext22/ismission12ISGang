// Author Ryan Pinkney, Tanner Davis, Kevin Gutierrez, Jacob Poor
// This is our model for designing how we will store infomration about people

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

        // Attribute to store the name
        [Required]
        public string Name { get; set; }

        // Attribute to store the size of the group
        [Required]
        [Range(1,15)]
        public int Size { get; set; }

        // Attribute to store their email
        [Required]
        public string Email { get; set; }

        // Attribute to store their phone number
        public string Phone { get; set; }
    }
}
