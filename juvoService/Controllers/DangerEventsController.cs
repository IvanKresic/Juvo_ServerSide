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
    public class DangerEventsController : TableController<DangerEvents>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            juvoContext context = new juvoContext();
            DomainManager = new EntityDomainManager<DangerEvents>(context, Request);
        }

        // GET tables/DangerEvents
        public IQueryable<DangerEvents> GetAllDangerEvents()
        {
            return Query(); 
        }

        // GET tables/DangerEvents/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<DangerEvents> GetDangerEvents(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/DangerEvents/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<DangerEvents> PatchDangerEvents(string id, Delta<DangerEvents> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/DangerEvents
        public async Task<IHttpActionResult> PostDangerEvents(DangerEvents item)
        {
            DangerEvents current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/DangerEvents/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteDangerEvents(string id)
        {
             return DeleteAsync(id);
        }
    }
}
