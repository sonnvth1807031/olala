﻿using Assinment.App_Start;
using Assinment.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Assinment.Controllers
{
    public class AccountsController : Controller
    {
        private IdentityConfig.ApplicationUserManager _userManager;
        public IdentityConfig.ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<IdentityConfig.ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public AccountsController()
        {

        }
        public AccountsController(IdentityConfig.ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(string username, string password)
        {
            Accountcs accountcs1 = new Accountcs() { 
                UserName = username,
            };
            var result = await UserManager.CreateAsync(accountcs1, password);
            Debug.WriteLine( result.Succeeded);
            if (result.Succeeded)
            {
                UserManager.AddToRole(accountcs1.Id, "User");
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = UserManager.CreateIdentity(accountcs1, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                return Redirect("/Home/Show");
            }
            return View("Register");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = UserManager.Find(username, password);
            if (user != null)
            {
                var authenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                return Redirect("/Home/Show");
            }
            return View("Login");
        }
        [Authorize]
        public ActionResult LogOut()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return Redirect("/Home");
        }
    }
}