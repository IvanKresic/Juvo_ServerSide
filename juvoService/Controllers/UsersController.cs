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
    public class UsersController : TableController<Users>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            juvoContext context = new juvoContext();
            DomainManager = new EntityDomainManager<Users>(context, Request);
        }

        // GET tables/users
        public IQueryable<Users> GetAllusers()
        {
            return Query(); 
        }

        // GET tables/users/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Users> Getusers(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/users/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Users> Patchusers(string id, Delta<Users> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/users
        public async Task<IHttpActionResult> Postusers(Users item)
        {
            Users current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.UsersID }, current);
        }

        // DELETE tables/users/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task Deleteusers(string id)
        {
             return DeleteAsync(id);
        }
    }
}
