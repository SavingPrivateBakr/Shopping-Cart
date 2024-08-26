using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_cart.Models
{

 

    public  class Food
    {
        public string Id { get; set;}

        public  double price;
        public double quantity { get; set; }
        
        public Customer customerId;

      

        

    }

}
