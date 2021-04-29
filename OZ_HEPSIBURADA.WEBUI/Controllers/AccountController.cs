using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OZ_HEPSIBURADA.WEBUI.Models.AccountVM;
using OZ_HEPSIBURADA.DAL.Context;
using OZ_HEPSIBURADA.DATA.Model_Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace OZ_HEPSIBURADA.WEBUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        //private readonly RoleManager<ApplicationRole> roleManager;

        public AccountController()
        {
            ECommerceContext DB = new ECommerceContext();

            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(DB);
            userManager = new UserManager<ApplicationUser>(userStore);

            //RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(DB);
            //roleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser comingUser = userManager.Find(model.UserName, model.Password);

                if (comingUser != null)
                {
                    IAuthenticationManager auth = HttpContext.GetOwinContext().Authentication;
                    ClaimsIdentity claimsIdentity = userManager.CreateIdentity(comingUser, "ApplicationCookie");
                    AuthenticationProperties authProperty = new AuthenticationProperties();
                    authProperty.IsPersistent = model.RememberMe;
                    auth.SignIn(authProperty, claimsIdentity);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Message"] = "There is no such a user.";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser comingUser = new ApplicationUser()
                {
                    UserName = model.UserName,
                    FullName = model.FullName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    DeliveryAddress = model.DeliveryAddress,
                    InvoiceAddress = model.InvoiceAddress
                };

                IdentityResult identityResult = userManager.Create(comingUser, model.Password);

                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(comingUser.Id, "User");
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(model);
        }

        [Authorize]
        public ActionResult LogOut()
        {
            IAuthenticationManager auth = HttpContext.GetOwinContext().Authentication;
            auth.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }
    }
}
