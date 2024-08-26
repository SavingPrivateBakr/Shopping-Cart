using System.ComponentModel.DataAnnotations;

namespace Shopping_cart.Models
{
    public class RegistirationModelView
    {
        [RegularExpression("^[A-Za-z ]+$")]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="مش صح لا")]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.EmailAddress)]
  
        public string Email { get; set; }
    }
}
