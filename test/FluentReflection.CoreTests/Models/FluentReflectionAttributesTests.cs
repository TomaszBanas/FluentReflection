using FluentAssertions;
using FluentReflection.Abstraction.Enums;
using FluentReflection.Core.Extensions;
using FluentReflection.TestData.TestData.Attributes;
using FluentReflection.TestData.TestData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FluentReflection.CoreTests.Models
{
    public class FluentReflectionAttributesTests
    {
        [Fact()]
        public void ClassWithAttributesIsCorrect()
        {
            var model = new ClassWithAttributes();
            var test = model.AsFluentReflection();
            test.Attributes.Should().NotBeNull();
            test.Attributes.Should().HaveCount(4);
        }
        
        [Fact()]
        public void ClassWithAttributesSelection()
        {
            var model = new ClassWithAttributes();
            var test = model.AsFluentReflection();
            var properties = test.Properties.Where(x => x.HasAttribute<Test2Attribute>() || x.HasAttribute<TestAttribute>()).ToList();
            properties.Should().NotBeNull();
            properties.Should().HaveCount(3);
        }
    }
}
