using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MTERoads.Models;
using System.Collections;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Data.Entity;

namespace MTERoads.Controllers
{
    public class TransactionsController : Controller
    {
        RoadsEntities mydb = new RoadsEntities();
        // GET: Transactions
        public ActionResult Index()
        {
            TransactionsViewModel vm = new TransactionsViewModel();
            vm.Emps = mydb.tblEmps.ToList();
            ViewData["Emps"] = vm.Emps;
            ViewData["defaultEmp"] = vm.Emps.First();
            vm.Machs = mydb.tblMaches.ToList();
            vm.Roads = mydb.tblRoads.ToList();
            vm.Acts = mydb.tblActs.ToList();
            vm.List = Read();
            return View("Transactions", vm);

            //return View("TransactionsGrid", Read());
        }


        public ActionResult EditTransaction(String n)
        {
            TransactionsViewModel vm = new TransactionsViewModel();
            vm.Emps = mydb.tblEmps.ToList();
            vm.Machs = mydb.tblMaches.ToList();
            vm.Roads = mydb.tblRoads.ToList();
            vm.Acts = mydb.tblActs.ToList();
            
            return PartialView("TransactionsWebGrid", vm);
        }
        [HttpGet]
        public void Add(String txtDate, String txtEmp)
        {
            

            TempData["www"] = txtDate;
        }

        [HttpPost]
        public ActionResult AddPost(String txtDate, String txtEmp, String txtRoad,
            String txtMach, String txtAct, String txtLease, String txtHours)
        {
            TempData["www"] = txtDate;
            mydb.AddRoadTrans(Int32.Parse(txtEmp), Int32.Parse(txtMach),
                Int32.Parse(txtAct), Int32.Parse(txtRoad), double.Parse(txtHours),
                double.Parse(txtLease), Convert.ToDateTime(txtDate));

            
           
            return RedirectToAction("Index");
        }

        public IEnumerable<tblTransaction> Read()
        {
            return mydb.tblTransactions;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult tblTransactions_Update(tblTransaction tblTransaction)
        {
            if (ModelState.IsValid)
            {

                var Hours = tblTransaction.Hours;
                   var  Lease_Chg = tblTransaction.Lease_Chg;
                mydb.tblTransactions.Find(tblTransaction.AutoNumber).Hours = Hours;

                mydb.tblTransactions.Find(tblTransaction.AutoNumber).Lease_Chg = Lease_Chg;
                mydb.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            mydb.Dispose();

            base.Dispose(disposing);
        }
    }
}
