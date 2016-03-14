﻿using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using JsonLD.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Hydra.Core
{
    /// <summary>
    /// Base class for Hydra API documentation
    /// </summary>
    [SerializeCompacted]
    public abstract class ApiDocumentation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiDocumentation"/> class.
        /// </summary>
        /// <param name="entrypoint">The entrypoint Uri.</param>
        protected ApiDocumentation(Uri entrypoint)
        {
            Entrypoint = entrypoint;
        }

        /// <summary>
        /// Gets or sets the API documentation identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets the entrypoint Uri.
        /// </summary>
        [JsonProperty(Hydra.entrypoint)]
        public Uri Entrypoint { get; private set; }

        /// <summary>
        /// Gets the supported classes.
        /// </summary>
        [JsonProperty(Hydra.supportedClass)]
        public virtual IEnumerable<Class> SupportedClasses
        {
            get { yield break; }
        }

        [JsonProperty, UsedImplicitly]
        private string Type
        {
            get { return Hydra.ApiDocumentation; }
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <param name="doc">The document.</param>
        [UsedImplicitly]
        protected static JToken GetContext(ApiDocumentation doc)
        {
            return new JArray(Hydra.Context, doc.GetLocalContext());
        }

        /// <summary>
        /// Gets the local @context for API documentation.
        /// </summary>
        protected abstract JToken GetLocalContext();
    }
}