using Microsoft.Azure.Mobile.Server;
using System.Collections.Generic;

namespace juvoService.DataObjects
{
    public class Users : EntityData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Devices = new HashSet<Devices>();
        }

        public int UsersID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TimeZone { get; set; }
        public bool Activated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Devices> Devices { get; set; }
    }
}