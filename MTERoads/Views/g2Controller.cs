using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Kendo.Mvc.Extensions;
using MTERoads.Models;
using System.Data.Entity;

namespace MTERoads.Views
{
    public class tblTransactionService : IDisposable
    {
        private RoadsEntities db;

        public tblTransactionService(RoadsEntities db)
        {
            this.db = db;
        }

        public IEnumerable<tblTransaction> Read()
        {
            return db.tblTransactions;  
        }

        public void Update(tblTransaction tblTransaction)
        {
            var entity = new tblTransaction
            {
                AutoNumber = tblTransaction.AutoNumber,
                Trans_Date = tblTransaction.Trans_Date,
                Hours = tblTransaction.Hours,
                Lease_Chg = tblTransaction.Lease_Chg,
                tblAct = tblTransaction.tblAct,
                tblEmp = tblTransaction.tblEmp,
                tblMach = tblTransaction.tblMach,
                tblRoad = tblTransaction.tblRoad
            };

            db.tblTransactions.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges(); 
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }

    public class g2Controller : Controller
    {
        private tblTransactionService tblTransactionService;

        public g2Controller()
        {
            tblTransactionService = new tblTransactionService(new RoadsEntities());
        }

        protected override void Dispose(bool disposing)
        {
            tblTransactionService.Dispose();

            base.Dispose(disposing);
        }

        public ActionResult g2()
        {
            return View(tblTransactionService.Read());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult tblTransactions_Update(tblTransaction tblTransaction)
        {
            if (ModelState.IsValid)
            {
                tblTransactionService.Update(tblTransaction);

                RouteValueDictionary routeValues = this.GridRouteValues();
                return RedirectToAction("g2", routeValues);
            }

            return View("g2", tblTransactionService.Read());
        }
    }
}
