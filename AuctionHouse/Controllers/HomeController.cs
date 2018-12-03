using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuctionHouse.Models;
using AuctionHouse.Services;

namespace AuctionHouse.Controllers {
    public class HomeController : Controller {
        
        public IActionResult Index([FromServices] AuctionApiProxy auctionApi) {
           IEnumerable<AuctionItems>  auctionItems = auctionApi.GetItemsAsync().Result;


            return View(auctionItems);
        }

        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
