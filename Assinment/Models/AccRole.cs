using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assinment.Models
{
    public class AccRole : IdentityRole
    {
        public AccRole() : base() { }
        public AccRole(string name) : base(name) { }
    }
}