﻿using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using NullGuard;

namespace Argolis.Hydra.Core
{
    /// <summary>
    /// Represents a Hydra IRI Template
    /// </summary>
    [NullGuard(ValidationFlags.ReturnValues)]
    public class IriTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IriTemplate"/> class.
        /// </summary>
        public IriTemplate()
        {
            this.VariableRepresentation = VariableRepresentation.BasicRepresentation;
            this.Mappings = new List<IriTemplateMapping>();
        }

        /// <summary>
        /// Gets or sets the variable representation
        /// </summary>
        [JsonProperty(Vocab.Hydra.variableRepresentation)]
        public VariableRepresentation VariableRepresentation { get; set; }

        /// <summary>
        /// Gets or sets the template
        /// </summary>
        [JsonProperty(Vocab.Hydra.template)]
        public string Template { get; set; }

        /// <summary>
        /// Gets or sets the IRI Template variable mappings
        /// </summary>
        [JsonProperty(Vocab.Hydra.mapping)]
        public IList<IriTemplateMapping> Mappings { get; set; }

        [JsonProperty, UsedImplicitly]
        private string Type => Vocab.Hydra.IriTemplate;
    }
}