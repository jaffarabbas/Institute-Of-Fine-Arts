//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_Institute_Of_Fine_Arts_Database_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class RESULT_ENTRIES_MODEL
    {
        public int RES_ID { get; set; }
        [Required(ErrorMessage = "Feild Required")]
        public int RES_WORK_ID { get; set; }
        [Required(ErrorMessage = "Feild Required")]
        public int RES_MARKS { get; set; }
        [Required(ErrorMessage = "Feild Required")]
        public System.DateTime RES_DATE { get; set; }
        [Required(ErrorMessage = "Feild Required")]
        public string RES_GRADE { get; set; }
        [Required(ErrorMessage = "Feild Required")]
        public Nullable<bool> RES_IS_ELIGIBLE { get; set; }
    
        public virtual RESULT_MODEL RESULT { get; set; }
        public virtual WORK_OF_COMPITITION_MODEL WORK_OF_COMPITITION { get; set; }
    }
}
