using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Staycation.Domain.Model
{
    public class UserModel
    {
        [BindNever]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Enter Your FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter Your LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter to your enable login")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter your to enable Login")]
        public string Password { get; set; }

        public string FullName { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public UserModel(string email, string password, string firstName, string lastName)
        {
            UserId = Guid.NewGuid().ToString();
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            FullName = $"{FirstName} {LastName}";
        }

    }
}
