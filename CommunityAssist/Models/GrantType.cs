//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CommunityAssist.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GrantType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GrantType()
        {
            this.GrantApplications = new HashSet<GrantApplication>();
        }
    
        public int GrantTypeKey { get; set; }
        public string GrantTypeName { get; set; }
        public string GrantTypeDescription { get; set; }
        public decimal GrantTypemaximum { get; set; }
        public decimal GrantTypeLifetimeMaximum { get; set; }
        public Nullable<System.DateTime> GrantTypeDateEntered { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrantApplication> GrantApplications { get; set; }
    }
}
