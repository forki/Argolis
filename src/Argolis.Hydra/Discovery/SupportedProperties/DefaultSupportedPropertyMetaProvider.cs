﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Argolis.Hydra.Annotations;
using Argolis.Hydra.Discovery.SupportedClasses;
using Newtonsoft.Json.Serialization;

namespace Argolis.Hydra.Discovery.SupportedProperties
{
    /// <summary>
    /// Default implementation of <see cref="ISupportedPropertyMetaProvider"/>
    /// </summary>
    public class DefaultSupportedPropertyMetaProvider : ISupportedPropertyMetaProvider
    {
        private const string DefaultDescription = "The {0} property";
        private readonly CamelCasePropertyNamesContractResolver propertyNames = new CamelCasePropertyNamesContractResolver();

        /// <summary>
        /// Gets the <see cref="SupportedPropertyMeta"/> based on property features
        /// and common attributes.
        /// </summary>
        public virtual SupportedPropertyMeta GetMeta(PropertyInfo property)
        {
            var isReadonly = property.SetMethod == null || property.SetMethod.IsPrivate || HasReadonlyAttribute(property);
            var title = this.propertyNames.GetResolvedPropertyName(property.Name);
            var description = property.GetDescription() ?? string.Format(DefaultDescription, title);
            var isWriteOnly = property.GetMethod == null ||
                              property.GetMethod.IsPrivate ||
                              property.GetCustomAttribute<WriteOnlyAttribute>() != null;
            var isRequired = property.GetCustomAttribute<RequiredAttribute>() != null;
            var isLink = property.GetCustomAttribute<LinkAttribute>() != null;

            return new SupportedPropertyMeta
            {
                Title = title,
                Description = description,
                Writeable = isReadonly == false,
                Readable = isWriteOnly == false,
                Required = isRequired,
                IsLink = isLink
            };
        }

        private static bool HasReadonlyAttribute(PropertyInfo property)
        {
            var readOnlyAttribute = property.GetCustomAttribute<ReadOnlyAttribute>();

            return readOnlyAttribute != null && readOnlyAttribute.IsReadOnly;
        }
    }
}
