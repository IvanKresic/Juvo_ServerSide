using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using juvoService.DataObjects;
using juvoService.Models;

namespace juvoService.Controllers
{
    [Authorize]
    public class DevicesController : TableController<Devices>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            juvoContext context = new juvoContext();
            DomainManager = new EntityDomainManager<Devices>(context, Request);
        }

        // GET tables/Devices
        public IQueryable<Devices> GetAllDevices()
        {
            return Query(); 
        }

        // GET tables/Devices/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Devices> GetDevices(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Devices/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Devices> PatchDevices(string id, Delta<Devices> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Devices
        public async Task<IHttpActionResult> PostDevices(Devices item)
        {
            Devices current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Devices/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteDevices(string id)
        {
             return DeleteAsync(id);
        }
    }
}
