//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace juvoService.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public partial class Devices
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Devices()
        {
            this.DangerEvents = new HashSet<DangerEvents>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangerEvents> DangerEvents { get; set; }

        [JsonIgnore]
        public virtual Users Users { get; set; }
    }
}
