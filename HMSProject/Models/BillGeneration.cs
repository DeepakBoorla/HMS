//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMSProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BillGeneration
    {
        public int BillId { get; set; }
        public string Patient_Name { get; set; }
        public Nullable<decimal> Total_Amount { get; set; }
        public Nullable<decimal> Amount_Paid { get; set; }
        public Nullable<decimal> Balance { get; set; }
    }
}
