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

    public partial class ASSIGNED_MODEL
    {
        public int ASI_ID { get; set; }
        [Required(ErrorMessage = "Feild Required")]
        public int ASI_STFL_ID { get; set; }
        [Required(ErrorMessage = "Feild Required")]
        public int ASI_CR_ID { get; set; }
        public System.DateTime ASI_DATE { get; set; }

        public virtual COURS_MODEL COURS { get; set; }
        public virtual STAFF_LOGIN_MODEL STAFF_LOGIN { get; set; }
    }
}