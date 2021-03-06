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

    public partial class STUDENT_LOGIN_MODEL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STUDENT_LOGIN_MODEL()
        {
            this.REGISTRATIONs = new HashSet<REGISTRATION_MODEL>();
            this.STUDENT_DETAILS = new HashSet<STUDENT_DETAILS_MODEL>();
        }
    
        public int STDL_ID { get; set; }
        public string STDL_NAME { get; set; }
        [Required(ErrorMessage = "Password must be required")]
    //    [RegularExpression(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Inavlid Password")]
        [DataType(DataType.Password)]
        public string STDL_PASSWORD { get; set; }
        public string STDL_PROFILE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGISTRATION_MODEL> REGISTRATIONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENT_DETAILS_MODEL> STUDENT_DETAILS { get; set; }
    }
}
