//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace credit_management_system
{
    using System;
    using System.Collections.Generic;
    
    public partial class cibil
    {
        public int u_id { get; set; }
        public Nullable<int> c_score { get; set; }
        public Nullable<bool> blocked { get; set; }
        public Nullable<int> balance { get; set; }
        public Nullable<int> overdue { get; set; }
    
        public virtual user user { get; set; }
    }
}
