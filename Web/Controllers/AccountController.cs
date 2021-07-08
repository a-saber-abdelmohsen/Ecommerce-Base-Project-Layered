using BL.AppServices;
using BL.ViewModels;
using DAL.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class AccountController : Controller
    {

        //Account service 
        AccountAppService accountAppService = new AccountAppService();


        // GET: Account
        public ActionResult Register() => View();
        [HttpPost]
        public ActionResult Register(RegisterViewModel newUser)
        {
            if (!ModelState.IsValid)
                return View(newUser);

            IdentityResult result = accountAppService.Register(newUser);
            if (result.Succeeded)
            {
                IAuthenticationManager owinManager = HttpContext.GetOwinContext().Authentication;
                //SignIn

                SignInManager<ApplicationUser, string> signInManager = new SignInManager<ApplicationUser, string>(
                    new ApplicationUserManager(),owinManager
                    );

                var user = accountAppService.Find(newUser.Username, newUser.PasswordHash);
                //checkbox for rememberMe
                signInManager.SignIn(user, true, true);
                return RedirectToAction("Index","Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return View(newUser);
            }
                
        }


        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            if (ModelState.IsValid == false)
            {
                return View(user);
            }

            ApplicationUser identityUser = accountAppService.FindByEmailAndPassword(user.Email, user.PasswordHash).Result;

            if (identityUser != null)
            {
                IAuthenticationManager owinMAnager = HttpContext.GetOwinContext().Authentication;
                //SignIn
                SignInManager<ApplicationUser, string> signinmanager =
                    new SignInManager<ApplicationUser, string>(
                        new ApplicationUserManager(), owinMAnager
                        );
                signinmanager.SignIn(identityUser, true, true);
                return RedirectToAction("Index", "Order");
            }
            else
            {
                ModelState.AddModelError("", "Not Valid Username & Password");
                return View(user);
            }

        }
        [Authorize]
        public ActionResult Logout()
        {
            IAuthenticationManager owinMAnager = HttpContext.GetOwinContext().Authentication;
            owinMAnager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }



    }
}