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

        //刪除

        public ActionResult DeleteCard(string Name) {
            DBmessage dBmessage = new DBmessage();
            dBmessage.DeletrCardByName(Name);
            return RedirectToAction("Index");
        }



        //更新


        public ActionResult EdidCard(int id)
        {
            DBmessage dBmessage = new DBmessage();
            Card card = dBmessage.GetCardsById(id);

            return View(card);
        }
        [HttpPost]
        public ActionResult EdidCard(Card card)
        {
            DBmessage dBmessage = new DBmessage();
            dBmessage.UpDataCard(card);

            return RedirectToAction("Index");
        }

        //勾選狀態
        public ActionResult CheckboxGet(int id)
        {
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult CheckboxGet(Card card) {
            DBmessage dBmessage = new DBmessage();
            dBmessage.UpDataSchedule(card);

            return RedirectToAction("Index");

        }
        //復原
        public ActionResult recoveryCard(Card card) {
            DBmessage dBmessage = new DBmessage();
            dBmessage.UpDataSchedule(card);

            return RedirectToAction("Index");

        }

        //其他
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

        //return content 

        public ActionResult HelloContent(string hi) {
            ViewData["data"] = "Hello world";
            DBmessage dBmessage = new DBmessage();

            return Content("eqwiofhuiwenj");
        }

    }
}