using Microsoft.Azure.Mobile.Server;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;

using XamarinCRMv2CatalogDataService.DataObjects;
using XamarinCRMv2CatalogDataService.Models;

namespace XamarinCRMv2CatalogDataService.Controllers
{
    public class AccountController : TableController<Account>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Account>(context, Request);
        }

        // GET tables/Account
        public IQueryable<Account> GetAllAccount()
        {
            return Query().ToList().AsQueryable(); 
        }

        // GET tables/Account/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Account GetAccount(string id)
        {
            return Lookup(id).Queryable.FirstOrDefault();
        }

        // PATCH tables/Account/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Account> PatchAccount(string id, Delta<Account> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Account
        public async Task<IHttpActionResult> PostAccount(Account item)
        {
            Account current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Account/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAccount(string id)
        {
             return DeleteAsync(id);
        }

    }
}