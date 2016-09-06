using MTERoads.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using MTERoads.Models;

namespace MTERoads.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        RoadsEntities mydb = new RoadsEntities();
        public ActionResult Index()
        {
            return View("LogIn");
        }
        [HttpPost]
        public ActionResult MyAction(String un, String pw)
        {
            //RoadsEntities mydb = new RoadsEntities();
            var list = mydb.Users.ToList();
            Boolean ex = list.Any(i => i.UserName == un && i.Password==pw);
            if (ex)
            {
                return View("Welcome");
            }
            else
            {
                if (un!="")
                ModelState.AddModelError(string.Empty, "The password or username is not correct.");
                return View("LogIn");
            }
                
        }
        public ActionResult Logout()
        {
            return View("LogIn");
        }

        public ActionResult Roads()
        {
            //tblRoad r = new tblRoad();
            //IEnumerable<MTERoads.Models.tblRoad> ie = new List<MTERoads.Models.tblRoad>();
            ViewBag.RoadTypes = mydb.tblTypes.ToList();
            return View("../Roda/Roads");
        }
        //[HttpGet]
        //public ActionResult AddNewRoad()
        //{
        //    tblRoad r = new tblRoad();
        //    IEnumerable<MTERoads.Models.tblRoad> ie = new List<MTERoads.Models.tblRoad>();
        //    //var tuple = new Tuple<MTERoads.Models.tblRoad, IEnumerable<MTERoads.Models.tblRoad>>(r, ie);
        //    return View(Tuple.Create(r, ie));
        //}
    }
}