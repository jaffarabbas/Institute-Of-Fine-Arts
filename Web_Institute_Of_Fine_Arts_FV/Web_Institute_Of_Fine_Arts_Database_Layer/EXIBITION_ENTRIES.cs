//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_Institute_Of_Fine_Arts_Database_Layer
{
    using System;
    using System.Collections.Generic;
    
    public partial class EXIBITION_ENTRIES
    {
        public int EXB_EN_EXB_ID { get; set; }
        public int EXB_EN_RES_ID { get; set; }
        public decimal PRICE { get; set; }
    
        public virtual EXIBITION EXIBITION { get; set; }
        public virtual REGISTRATION REGISTRATION { get; set; }
    }
}
