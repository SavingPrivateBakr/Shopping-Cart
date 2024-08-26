using System.ComponentModel.DataAnnotations;

namespace Shopping_cart.Models
{
    public class SendingKilosAndREQ
    {
        
        public double prices { get; set; }

      [Range(0, int.MaxValue, ErrorMessage = "يا اخي ")]
        [Maximum(ErrorMessage ="Nope")]
        public  double kilos { get;set; }

        [Required]
        public  int ID { get; set; }
        [Required]
        public string IDD { get; set; }
    }
}
