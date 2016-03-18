﻿using FluentAssertions;
using Hydra.DocumentationDiscovery;
using TestHydraApi;
using Xunit;

namespace Lernaean.Hydra.Tests.ApiDocumentation
{
    public class AssemblySupportedClassSourceTests
    {
        private readonly AssemblyAnnotatedTypeSelector _source;

        public AssemblySupportedClassSourceTests()
        {
            _source = new AssemblyAnnotatedTypeSelector(typeof(Issue).Assembly);
        }

        [Fact]
        public void Should_discover_annotated_supported_classes()
        {
            // when
            var supportedClasses = _source.FindTypes();

            // then
            supportedClasses.Should().NotContain(typeof (UndocumentedClass));
        }
    }
}