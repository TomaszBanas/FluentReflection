using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using FluentReflectionEmbeddedResourceGen.FluentReflection.Assembly.EmbeddedResource.SourceGeneratorTests;
using FluentReflectionEmbeddedResourceGen;

namespace FluentReflection.Assembly.EmbeddedResource.SourceGeneratorTests
{
    public class EmbededResourceTests
    {
        [Fact()]
        public void EmbededResourceClassExistsAndHasProipertyOfEachFile()
        {
            EmbeddedResources.EmbeddedResources1.test1json.Should().NotBeNullOrWhiteSpace().And.HaveLength(131);
            EmbeddedResources.EmbeddedResources1.test2json.Should().NotBeNullOrWhiteSpace().And.HaveLength(131);
            EmbeddedResources.EmbeddedResources2.test3json.Should().NotBeNullOrWhiteSpace().And.HaveLength(131);
            EmbeddedResources.EmbeddedResources2.test4json.Should().NotBeNullOrWhiteSpace().And.HaveLength(131);
            EmbeddedResources.EmbeddedResources1.SubEmbeddedResources3.test5json.Should().NotBeNullOrWhiteSpace().And.HaveLength(131);
            EmbeddedResources.EmbeddedResources1.SubEmbeddedResources3.test6json.Should().NotBeNullOrWhiteSpace().And.HaveLength(131);
        }
    }
}