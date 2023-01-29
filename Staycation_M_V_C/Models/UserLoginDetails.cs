using System.ComponentModel.DataAnnotations;

namespace Staycation.M_V_C.Models
{
    public class UserLoginDetails
    {
       
        [Required
        (ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password must contain a Capital Letter, a number and a special charater")]
        public string Password { get; set; }

        public UserLoginDetails(string email , string password)
        {
            Email = email;
            Password = password;
        }
        public UserLoginDetails()
        {

        }
    }
}
