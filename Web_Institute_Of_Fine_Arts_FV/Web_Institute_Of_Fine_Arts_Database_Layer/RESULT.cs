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
    
    public partial class RESULT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RESULT()
        {
            this.RESULT_ENTRIES = new HashSet<RESULT_ENTRIES>();
        }
    
        public int RES_ID { get; set; }
        public int RES_COM_ID { get; set; }
    
        public virtual COMPITITION COMPITITION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESULT_ENTRIES> RESULT_ENTRIES { get; set; }
    }
}