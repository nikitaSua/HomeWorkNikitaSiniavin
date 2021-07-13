using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Practice_Forms.Models
{
    public class User:IEntity
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string LastName { get; set; }

        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        public string Email { get; set; }

        public bool IsConfirmedPass { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
