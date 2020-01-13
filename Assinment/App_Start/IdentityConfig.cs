﻿using Assinment.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assinment.App_Start
{
    public class IdentityConfig
    {
        public class ApplicationUserManager : UserManager<Accountcs>
        {
            public ApplicationUserManager(IUserStore<Accountcs> store)
                : base(store)
            {
            }

            public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
                IOwinContext context)
            {
                var manager =
                    new ApplicationUserManager(new UserStore<Accountcs>(context.Get<AssinmentContext>()));
                return manager;
            }
        }
    }
}