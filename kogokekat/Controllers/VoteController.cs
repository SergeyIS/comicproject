using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kogokekat.DataAccess;
using kogokekat.Models;

namespace kogokekat.Controllers
{
    public class VoteController : Controller
    {
        private DataBaseEmulator db;
        public VoteController()
        {
            db = new DataBaseEmulator();
        }

        [HttpGet]
        public ActionResult Index(String id)
        {
            if(id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var query =  db.Participants.Where(p => p.Token.Equals(id, StringComparison.InvariantCultureIgnoreCase));
            if (query == null || query.Count() == 0)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
            if (query.First().IsVoted == false)
                return View("VoteAlready");

            Participant part = query.First();
            var others = db.Participants.Where(p => !p.Token.Equals(part.Token, StringComparison.InvariantCultureIgnoreCase)).ToList();

            ViewBag.token = part.Token;
            return View(others);
        }

        [HttpPost]
        public ActionResult Index(VoteResponseModel response)
        {
            if (response == null || response.Token == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var query = db.Participants.Where(p => p.Token.Equals(response.Token, StringComparison.InvariantCultureIgnoreCase));
            if (query == null || query.Count() == 0)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
            query.First().IsVoted = false;

            db.Participants.Where(p => p.Id == response.VictimId).First().Rating += 1;


            return View("Congratulation");
        }

        public ActionResult Results()
        {
            var parts = db.Participants.OrderByDescending(p=>p.Rating).ToList();
            
            return View(parts);
        }
    }
}