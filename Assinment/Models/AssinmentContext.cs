using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assinment.Models
{
    public class AssinmentContext : IdentityDbContext<Accountcs>
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AssinmentContext() : base("name=AssinmentContext")
        {
        }

        public static AssinmentContext Create()
        {
            return new AssinmentContext();
        }
        public System.Data.Entity.DbSet<Assinment.Models.Coin> Coins { get; set; }

        public System.Data.Entity.DbSet<Assinment.Models.Market> Markets { get; set; }
    }
}
