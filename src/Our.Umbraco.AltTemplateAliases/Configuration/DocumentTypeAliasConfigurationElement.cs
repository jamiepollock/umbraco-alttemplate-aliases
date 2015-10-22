using System.Configuration;

namespace Our.Umbraco.AltTemplateAliases.Configuration
{
    public class DocumentTypeAliasConfigurationElement : ConfigurationElement
    {
        private const string _aliasPropertyName = "alias";

        [ConfigurationProperty(_aliasPropertyName)]
        public string Alias
        {
            get { return (string)this[_aliasPropertyName]; }
            set { this[_aliasPropertyName] = value; }
        }
    }
}
