//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MTERoads.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblTransaction
    {
        public int AutoNumber { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Trans_Date { get; set; }
        public Nullable<int> Emp_No { get; set; }
        public Nullable<int> Mach_No { get; set; }
        public Nullable<int> BIA_No { get; set; }
        public Nullable<int> Activity_Code { get; set; }
        public Nullable<double> Hours { get; set; }
        public Nullable<double> Lease_Chg { get; set; }
    
        public virtual tblAct tblAct { get; set; }
        public virtual tblEmp tblEmp { get; set; }
        public virtual tblMach tblMach { get; set; }
        public virtual tblRoad tblRoad { get; set; }
    }
}
