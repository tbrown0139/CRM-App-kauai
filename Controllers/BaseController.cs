using Microsoft.Azure.Mobile.Server;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Controllers;

using XamarinCRMv2CatalogDataService.Models;

namespace XamarinCRMv2CatalogDataService.Controllers
{
    /// <summary>
    /// A base controller, to assist in implemting XML documentation for the API, and 
    /// to abstract away the common Initialize() method of the controllers.
    /// </summary>
    /// <typeparam name="T">The type of EntityData that the inheriting controller will be bound to.</typeparam>
    public abstract class BaseController<T> : TableController<T> where T : EntityData
    {
        private MobileServiceContext _MobileServiceContext;
        public MobileServiceContext MobileServiceContext
        {
            get { return _MobileServiceContext; }
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            _MobileServiceContext = new MobileServiceContext();
            DomainManager = new EntityDomainManager<T>(_MobileServiceContext, Request);
            //Configuration.SetDocumentationProvider(new XmlDocumentationProvider(Services));
        }
    }
}