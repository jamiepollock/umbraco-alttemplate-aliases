using Our.Umbraco.AltTemplateAliases.Configuration;
using System;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web.PublishedCache;

namespace Our.Umbraco.AltTemplateAliases.Services
{
    internal class ContentFinderHelperService
    {
        private const string _urlPathDelimiter = "/";

        internal IPublishedContent FindCachedContentByUrl(ContextualPublishedContentCache cache, string url)
        {
            return cache.GetByRoute(url);
        }

        internal bool IsRuleAMatch(AltTemplateAliasRuleConfigurationElement rule, string absolutePath)
        {
            return absolutePath.EndsWith(rule.Alias);
        }

        internal bool ValidateNodeAgainstRule(IPublishedContent node, AltTemplateAliasRuleConfigurationElement rule)
        {
            if (rule.HasAllowedDocumentTypes == false) {
                return true;
            }
                
            return rule.HasAllowedDocumentTypes && 
                   rule.AllowedDocumentTypes.Any(documentType => string.Equals(documentType.Alias, node.DocumentTypeAlias, StringComparison.OrdinalIgnoreCase));
        }

        internal string SanitizeContentRequestUriToAbsolutePath(Uri uri)
        {
            var absolutePath = uri.GetAbsolutePathDecoded();

            if (IsAbsolutePathRoot(absolutePath)) {
                return absolutePath;
            }

            return absolutePath.TrimEnd(_urlPathDelimiter);
        }

        internal string RemoveAltTemplateFromUrl(string absolutePath, string templateAlias)
        {
            var sanitisedUrl = absolutePath.EndsWith(_urlPathDelimiter) ?
                absolutePath.TrimEnd(_urlPathDelimiter) :
                absolutePath;

            return sanitisedUrl.TrimEnd(templateAlias);            
        }

        private bool IsAbsolutePathRoot(string absolutePath)
        {
            return string.Equals(absolutePath, _urlPathDelimiter);
        }
    }
}
