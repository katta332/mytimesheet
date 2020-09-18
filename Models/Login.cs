using System;
using System.ComponentModel.DataAnnotations;

namespace AngularProject.Models
{
    public class Login
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

    }
}
