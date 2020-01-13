namespace Assinment.Migrations
{
    using Assinment.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assinment.Models.AssinmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Assinment.Models.AssinmentContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Markets.AddOrUpdate(
                m => m.Id,
                new Market() { Id = 1, Name = "AAA", Description = "OK" },
                new Market() { Id = 2, Name = "BBB", Description = "OK" },
                new Market() { Id = 3, Name = "CCC", Description = "OK" }
                );
            context.Coins.AddOrUpdate(
               c => c.Id,
               new Coin() { Id = "OK", Name = "SON1", BaseAsset = "SON1", QuoteAsset = "BTC", LastPrice = 9999.9999, Volumn24h = 89549689.909, MarketId = 1 },
               new Coin() { Id = "ANHSOn", Name = "SON2", BaseAsset = "SON2", QuoteAsset = "BTC", LastPrice = 888.888, Volumn24h = 8998.8786, MarketId = 1 },
               new Coin() { Id = "HIHI", Name = "Son3", BaseAsset = "SON3", QuoteAsset = "BTC", LastPrice = 8899898.89, Volumn24h = 8768.876, MarketId = 2 }
               );
            var roleStore = new RoleStore<AccRole>(context);
            var roleManager = new RoleManager<AccRole>(roleStore);
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var role = new AccRole("Admin");
                roleManager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "User"))
            {
                var role = new AccRole("User");
                roleManager.Create(role);
            }
            var store = new UserStore<Accountcs>(context);
            var manager = new UserManager<Accountcs>(store);
            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var user = new Accountcs() { UserName = "admin" };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
