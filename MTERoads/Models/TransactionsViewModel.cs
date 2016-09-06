using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTERoads.Models
{
    public class TransactionsViewModel
    {
        public tblTransaction Transaction { get; set; }
        public List<tblEmp> Emps { get; set; }
        public List<tblMach> Machs { get; set; }
        public List<tblRoad> Roads { get; set; }
        public List<tblAct> Acts { get; set; }
        public IEnumerable<tblTransaction> List { get; set; }
    }

}