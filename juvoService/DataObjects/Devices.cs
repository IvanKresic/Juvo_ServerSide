using System.Collections.Generic;
using Microsoft.Azure.Mobile.Server;

namespace juvoService.DataObjects
{
    public class Devices : EntityData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Devices()
        {
            this.DangerEvents = new HashSet<DangerEvents>();
        }

        public int DevicesID { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangerEvents> DangerEvents { get; set; }
        public virtual Users Users { get; set; }
    }
}