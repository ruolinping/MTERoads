using MTERoads.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTERoads.Controllers
{
    public class RodaController : Controller
    {
        // GET: Roda
        RoadsEntities mydb = new RoadsEntities();
        public ActionResult Index()
        {
            RoadsViewModel vm = new RoadsViewModel();
            vm.Item2 = ((IEnumerable)mydb.GetAllRoadsWithType()).Cast<object>().ToList();
            ViewBag.RoadTypes = mydb.tblTypes.ToList();
            
            return View("Roads", vm);
        }

        public ActionResult AddNewRoad(RoadsViewModel tuple)
        {
            //tblRoad r = new Order();
            if (tuple.Item1 != null)
            {
                mydb.tblRoads.Add(tuple.Item1);
                mydb.SaveChanges();
                ViewData["Message"] = "" + tuple.Item1.Road_Name;
                ModelState.Clear();
            }
            //ViewBag.RoadTypes = mydb.tblTypes.ToList();
            // RoadsViewModel vm = new RoadsViewModel();
            // vm.Item2 = ((IEnumerable)mydb.GetAllRoadsWithType()).Cast<object>().ToList();
            return Index();
        }

        public ActionResult EditRoad(String This_Code, String Edit_Name, String Edit_Miles, String Edit_Type)
        {
            if(This_Code!= null) { 
            var road = mydb.tblRoads.Find(Int32.Parse(This_Code));
            if (road!= null) {
                road.Road_Name = Edit_Name;
                road.Miles = double.Parse(Edit_Miles);
                road.Type_Id = Int32.Parse(Edit_Type);
                mydb.SaveChanges();
                ViewData["EditMessage"] = "Successfully edited road " + Edit_Name;
            }
            else {
                ViewData["EditMessage"] = "Edit did not success";
            }
            }
            return Index();
        }
    }
}