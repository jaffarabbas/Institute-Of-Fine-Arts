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
    using System.Web;

    public partial class WORK_OF_COMPITITION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WORK_OF_COMPITITION()
        {
            this.RESULT_ENTRIES = new HashSet<RESULT_ENTRIES>();
        }
    
        public int WOC_ID { get; set; }
        public int WOC_REG_ID { get; set; }
        public int WOC_COM_ID { get; set; }
        public string WOC_WORK { get; set; }
    
        public virtual COMPITITION COMPITITION { get; set; }
        public virtual REGISTRATION REGISTRATION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESULT_ENTRIES> RESULT_ENTRIES { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}
