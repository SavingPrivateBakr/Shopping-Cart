using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shopping_cart.Models;

namespace Shopping_cart.Controllers
{
    public class AccountController : Controller
    {

        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signinmanager;
        RoleManager<IdentityRole> rolemanager;
        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signinmanager,RoleManager<IdentityRole> rolemanager)
        {
            this.userManager = userManager;
            this.signinmanager = signinmanager;
            this.rolemanager= rolemanager;
           
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegistirationModelView NewR)
        {

            if (ModelState.IsValid)
            {

                ApplicationUser user = new ApplicationUser();
                user.Email = NewR.Email;
                user.UserName = NewR.Name;
                user.PasswordHash = NewR.Password;
                IdentityResult result = await userManager.CreateAsync(user, NewR.Password);

                IdentityRole identity = new IdentityRole();
                identity.Name = NewR.Name;
                
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user,"Customer");
                    await signinmanager.SignInAsync(user, false);
                    
                var w=   await userManager.FindByNameAsync(user.UserName);
                
                 

                   return RedirectToAction("CustomerService", "Customer", new {id=w.Id});
                }
                else
                {

             
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("Password", "zobry");
                    }


                }
                

            }


            return View(NewR);
        }
        [HttpGet]
        public IActionResult LogIn()
        {


            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> LogIn(LoginModelView login)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser app = await userManager.FindByNameAsync(login.Name);


           
               if ( app != null)
                {
                    if (await userManager.CheckPasswordAsync(app, login.Password) == false)
                    {
                        ModelState.AddModelError("", "Someting wrong");
                    }
                    else
                    {

                        var w = await userManager.FindByNameAsync(login.Name);
                        await signinmanager.SignInAsync(app, false);

                        return RedirectToAction("CustomerService", "Customer", new { id = w.Id });
                    }

                }
               else
                {
                    ModelState.AddModelError("Name", "اسمك مش موجود");
                }
                
            }

            return View(login);
        }
        public async Task<IActionResult> Logout()
        {
           await signinmanager.SignOutAsync();
           return RedirectToAction("LogIn");
        }

        }
    }
