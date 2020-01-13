using Assinment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assinment.Controllers
{
    public class HomeController : Controller
    {
        private AssinmentContext db = new AssinmentContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Show(int? marketId, string keyWord)
        {
            var coins = db.Coins.Where(c => c.Status == 0);
            if (marketId != null && marketId != 0)
            {
                ViewBag.CurrentMarketId = marketId;
                coins = coins.Where(c => c.MarketId == marketId);
            }
            if (keyWord != null)
            {
                ViewBag.CurrentKeyWord = keyWord;
                coins = coins.Where(c => c.Name.Contains(keyWord));
            }
            ViewBag.Markets = db.Markets;
            return View(coins.ToList());
        }
    }
}