using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shopping_cart.Models
{
    public class LoginModelView
    {
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [DefaultValue(false)]
        public bool RememberMe { get; set; }
    }
}
