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
    
    public partial class ASSIGNED
    {
        public int ASI_ID { get; set; }
        public int ASI_STFL_ID { get; set; }
        public int ASI_CR_ID { get; set; }
        public System.DateTime ASI_DATE { get; set; }
    
        public virtual COURS COURS { get; set; }
        public virtual STAFF_LOGIN STAFF_LOGIN { get; set; }
    }
}
