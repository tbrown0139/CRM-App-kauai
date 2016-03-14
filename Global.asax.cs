using System.Web;
using System.Web.Http;

namespace XamarinCRMv2CatalogDataService
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}