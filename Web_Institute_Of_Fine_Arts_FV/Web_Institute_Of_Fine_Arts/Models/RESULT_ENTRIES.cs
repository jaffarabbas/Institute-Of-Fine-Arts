//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_Institute_Of_Fine_Arts.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RESULT_ENTRIES
    {
        public int RES_ID { get; set; }
        public int RES_WORK_ID { get; set; }
        public decimal RES_MARKS { get; set; }
        public System.DateTime RES_DATE { get; set; }
        public string RES_GRADE { get; set; }
        public Nullable<bool> RES_IS_ELIGIBLE { get; set; }
    
        public virtual RESULT RESULT { get; set; }
        public virtual WORK_OF_COMPITITION WORK_OF_COMPITITION { get; set; }
    }
}
