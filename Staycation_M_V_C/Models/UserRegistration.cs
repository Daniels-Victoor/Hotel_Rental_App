using System.ComponentModel.DataAnnotations;

namespace Staycation.M_V_C.Models
{
    public class UserRegistration
    {
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$",
        ErrorMessage = "The password Must Contain A Capital letter, a number, A special number")]
        public string Password { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+$",
         ErrorMessage = "LastName must start with a capital Letter")]
        public string LastName { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+$",
         ErrorMessage = "FirstName must start with a capital Letter")]
        public string FirstName { get; set; }
      
      
        [Required(ErrorMessage = "Please Retype your password")]
        public string RetypePassword { get; set; }
    }
}
