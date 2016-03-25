using System;
using System.Reflection;
using JsonLD.Entities;
using Newtonsoft.Json;

namespace Hydra.Discovery.SupportedProperties
{
    /// <summary>
    /// Default <see cref="IPropertyPredicateIdPolicy"/> with a sensible
    /// fallback based on containing class
    /// </summary>
    public class DefaultPropertyIdPolicy : IPropertyPredicateIdPolicy
    {
        private readonly ContextResolver _contextResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultPropertyIdPolicy"/> class.
        /// </summary>
        public DefaultPropertyIdPolicy(IContextProvider contextProvider)
        {
            _contextResolver = new ContextResolver(contextProvider);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultPropertyIdPolicy"/> class.
        /// </summary>
        public DefaultPropertyIdPolicy() : this(new NullContextProvider())
        {
        }

        /// <summary>
        /// Gets the property identifier from the @context
        /// or as concatenation of class and property name.
        /// </summary>
        public string GetPropertyId(PropertyInfo property)
        {
            var context = _contextResolver.GetContext(property.ReflectedType);

            if (context != null)
            {
                return ContextHelpers.GetExpandedIri(context, property.GetJsonPropertyName());
            }

            return null;
        }
    }
}
