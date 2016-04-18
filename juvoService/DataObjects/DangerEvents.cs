using Microsoft.Azure.Mobile.Server;

namespace juvoService.DataObjects
{
    public class DangerEvents : EntityData
    {
        public int PrimaryID { get; set; }
        public int DeviceId { get; set; }
        public string HappenedAt { get; set; }

        public virtual Devices Devices { get; set; }
    }
}