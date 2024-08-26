using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shopping_cart.Models;
using Shopping_cart.Models.Databases;

namespace Shopping_cart.Controllers
{
    [Authorize(Roles ="Customer")]
    public class FoodController : Controller
    {
        ICustomer cust;

        public FoodController(ICustomer cust)
        {
            this.cust = cust;
        }


        
        public IActionResult calculation(int Id,string IDDD)
        {

            double o = navigator.Navigation(Id);
            SendingKilosAndREQ SS = new SendingKilosAndREQ();
            SS.prices = o;
            SS.ID = Id;
            SS.IDD = IDDD;
                
           return View(SS);
            
        }
        [HttpPost]
        public IActionResult calculationresult(SendingKilosAndREQ kkilos)
        {

            if (ModelState.IsValid)
            {
                double o = kkilos.prices * kkilos.kilos;
                
                cust.SaveChanges(kkilos.IDD,o);

                return RedirectToAction("CustomerService", "Customer", new { id= kkilos.IDD });
            }
            else
            {
                
                return View("calculation", kkilos);
            }

        }



    }
}
