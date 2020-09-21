using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using newProject01.Models;


namespace newProject01.Controllers
{
    public class HomeController : Controller
    {
        //查詢
        public ActionResult Index()
        {
            DBmessage dBmessage = new DBmessage();
            List<Card> cards = dBmessage.GetCards();

            ViewBag.cards = cards;
            return View();
        }

        //新增
        public ActionResult CreateCard()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCard(Card card)
        {
            DBmessage dbmessage = new DBmessage();
            try
            {
                dbmessage.NewCard(card);
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            return RedirectToAction("Index");
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}