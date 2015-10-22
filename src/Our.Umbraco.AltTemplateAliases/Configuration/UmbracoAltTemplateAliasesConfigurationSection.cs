using System.Configuration;
using System.Linq;

namespace Our.Umbraco.AltTemplateAliases.Configuration
{
    public class UmbracoAltTemplateAliasesConfigurationSection : ConfigurationSection
    {
        private const string _rulesElementName = "Rules";
        private const string _configurationSectionElementName = "Our.Umbraco.AltTemplateAliases";

        public static UmbracoAltTemplateAliasesConfigurationSection GetConfiguration()
        {
            return (UmbracoAltTemplateAliasesConfigurationSection)ConfigurationManager.GetSection(_configurationSectionElementName);
        }

        [ConfigurationProperty(_rulesElementName, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(AltTemplateAliasRuleConfigurationElementCollection))]
        public AltTemplateAliasRuleConfigurationElementCollection Rules
        {
            get
            {
                return (AltTemplateAliasRuleConfigurationElementCollection)base[_rulesElementName];
            }
        }

        public bool HasRules
        {
            get
            {
                return Rules.Any();
            }
        }
    }
}
