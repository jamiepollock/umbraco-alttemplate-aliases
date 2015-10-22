using System.Collections.Generic;
using System.Configuration;

namespace Our.Umbraco.AltTemplateAliases.Configuration
{
    public abstract class GenericConfigurationElementCollection<TConfigurationElement> : ConfigurationElementCollection, IReadOnlyCollection<TConfigurationElement> where TConfigurationElement : ConfigurationElement, new()
    {
        private List<TConfigurationElement> _elements = new List<TConfigurationElement>();

        protected override ConfigurationElement CreateNewElement()
        {
            var newElement = new TConfigurationElement();
            _elements.Add(newElement);
            return newElement;
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return _elements.Find(e => e.Equals(element));
        }

        public new IEnumerator<TConfigurationElement> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }
    }
}
