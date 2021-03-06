﻿using System;
using Argolis.Hydra.Core;
using Vocab;

namespace Argolis.Hydra.Annotations
{
    /// <summary>
    /// Use to mark a <see cref="SupportedProperty"/>, which should
    /// not be <see cref="Vocab.Hydra.readable"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class WriteOnlyAttribute : Attribute
    {
    }
}
