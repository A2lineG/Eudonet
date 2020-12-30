using System;
using System.ComponentModel.DataAnnotations;

namespace EudonetExercice.Entities
{
    public class Client
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }       
    }
}
