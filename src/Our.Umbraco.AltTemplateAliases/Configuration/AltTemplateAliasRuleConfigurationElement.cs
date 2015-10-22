using System.Configuration;
using System.Linq;

namespace Our.Umbraco.AltTemplateAliases.Configuration
{
    public class AltTemplateAliasRuleConfigurationElement : ConfigurationElement
    {
        private const string _aliasPropertyName = "alias";
        private const string _umbracoTemplateAliasPropertyName = "umbracoTemplateAlias";
        private const string _allowedDocumentTypesElementName = "AllowedDocumentTypes";

        [ConfigurationProperty(_aliasPropertyName, IsRequired = true)]
        public string Alias
        {
            get { return (string)this[_aliasPropertyName]; }
            set { this[_aliasPropertyName] = value; }
        }
        [ConfigurationProperty(_umbracoTemplateAliasPropertyName, IsRequired = true)]
        public string UmbracoTemplateAlias
        {
            get { return (string)this[_umbracoTemplateAliasPropertyName]; }
            set { this[_umbracoTemplateAliasPropertyName] = value; }
        }

        [ConfigurationProperty(_allowedDocumentTypesElementName, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(DocumentTypeAliasConfigurationElementCollection))]
        public DocumentTypeAliasConfigurationElementCollection AllowedDocumentTypes
        {
            get { return (DocumentTypeAliasConfigurationElementCollection)this[_allowedDocumentTypesElementName]; }
        }

        public bool HasAllowedDocumentTypes
        {
            get { return AllowedDocumentTypes.Any(); }
        }
    }
}
