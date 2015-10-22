using Our.Umbraco.AltTemplateAliases.Routing;
using Umbraco.Core;
using Umbraco.Web.Routing;

namespace Our.Umbraco.AltTemplateAliases
{
    public class Bootstrapper : ApplicationEventHandler
    {
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            ContentFinderResolver.Current.InsertTypeBefore<ContentFinderByNotFoundHandlers, AltTemplateAliasContentFinder>();
        }
    }
}
