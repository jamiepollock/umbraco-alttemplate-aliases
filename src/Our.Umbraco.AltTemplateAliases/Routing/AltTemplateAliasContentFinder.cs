using Our.Umbraco.AltTemplateAliases.Configuration;
using Our.Umbraco.AltTemplateAliases.Services;
using Umbraco.Core.Logging;
using Umbraco.Web.Routing;

namespace Our.Umbraco.AltTemplateAliases.Routing
{
    public class AltTemplateAliasContentFinder : IContentFinder
    {
        private readonly UmbracoAltTemplateAliasesConfigurationSection _config = UmbracoAltTemplateAliasesConfigurationSection.GetConfiguration();

        public bool TryFindContent(PublishedContentRequest contentRequest)
        {
            if (_config == null || _config.HasRules == false)
            {
                LogHelper.Info<AltTemplateAliasContentFinder>("Skipping AltTemplateAliasContentFinder. No custom configuration or rules set.");
                return false;
            }

            var service = new ContentFinderHelperService();
            var umbracoContext = contentRequest.RoutingContext.UmbracoContext;

            foreach (var rule in _config.Rules)
            {
                var absolutePath = service.SanitizeContentRequestUriToAbsolutePath(contentRequest.Uri);

                if (service.IsRuleAMatch(rule, absolutePath))
                {
                    var pathWithoutAltTemplateAlias = service.RemoveAltTemplateFromUrl(absolutePath, rule.Alias);
                    var node = service.FindCachedContentByUrl(umbracoContext.ContentCache, pathWithoutAltTemplateAlias);

                    if (node != null && service.ValidateNodeAgainstRule(node, rule))
                    {
                        var template = umbracoContext.Application.Services.FileService.GetTemplate(rule.UmbracoTemplateAlias);

                        if (template != null)
                        {
                            contentRequest.PublishedContent = node;
                            contentRequest.SetTemplate(template);
                        }
                    }
                }
            }

            return contentRequest != null && contentRequest.PublishedContent != null;
        }
    }
}
