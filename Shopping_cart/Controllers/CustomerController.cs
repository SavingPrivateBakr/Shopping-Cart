using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping_cart.Models;
using Shopping_cart.Models.Databases;
using System.ComponentModel;
using System.Data;

namespace Shopping_cart.Controllers
{
  
    public class CustomerController : Controller
    {


        ICustomer cust;

        public CustomerController(ICustomer cc)
        {
           
            cust = cc;
        }
        // [Route("Customer/CustomerService/rr?=1")]

        [Authorize(Roles = "Customer")]
        public IActionResult CustomerService(string id)
        {
           
            cust.GetID(id);
         double o=   cust.GetTotal(id);
            TempData["id"] = id;
            TempData.Keep("id");
            
            return View(o);
        }
    }
}
