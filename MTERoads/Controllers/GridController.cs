﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MTERoads.Models;

namespace MTERoads.Views.Transactions
{
    public class GridController : Controller
    {
        private RoadsEntities db = new RoadsEntities();

        public ActionResult tran()
        {
            return View("tran");
        }

        public ActionResult tblTransactions_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<tblTransaction> tbltransactions = db.tblTransactions;
            DataSourceResult result = tbltransactions.ToDataSourceResult(request, tblTransaction => new {
                AutoNumber = tblTransaction.AutoNumber,
                Trans_Date = tblTransaction.Trans_Date,
                Hours = tblTransaction.Hours,
                Lease_Chg = tblTransaction.Lease_Chg,
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult tblTransactions_Update([DataSourceRequest]DataSourceRequest request, tblTransaction tblTransaction)
        {
            if (ModelState.IsValid)
            {
                var entity = new tblTransaction
                {
                    AutoNumber = tblTransaction.AutoNumber,
                    Trans_Date = tblTransaction.Trans_Date,
                    Hours = tblTransaction.Hours,
                    Lease_Chg = tblTransaction.Lease_Chg,
                };

                db.tblTransactions.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { tblTransaction }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
