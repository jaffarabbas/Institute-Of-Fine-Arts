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
    
    public partial class STUDENT_DETAILS
    {
        public int SD_STDL_ID { get; set; }
        public string STD_ADDRESS { get; set; }
        public string STD_EMAIL { get; set; }
        public string STD_PHONE { get; set; }
        public System.DateTime STD_DATE_OF_BIRTH { get; set; }
    
        public virtual STUDENT_LOGIN STUDENT_LOGIN { get; set; }
    }
}
