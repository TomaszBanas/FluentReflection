using FluentAssertions;
using FluentReflection.Core.Extensions;
using FluentReflection.TestData.TestData.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FluentReflection.CoreTests.Tests
{

    public class FluentReflectionCase01Tests
    {
        private class Case01
        {
            [Test(SomeDataCode = "Identifier", SomeIntValue = 1)]
            public string Id { get; set; }

            [Test(SomeDataCode = "UserName", SomeIntValue = 2)]
            public string Name { get; set; }
        }


        [Fact()]
        public void ClassWithAttributesIsCorrect()
        {
            var reflection = ReflectionExtensions.Reflect(typeof(Case01));

            var result = reflection.Properties
                .SelectMany(x => x.Attributes.Where(a => a.Is<TestAttribute>()).Select(a => new { Attr = a.As<TestAttribute>(), Prop = x }))
                .Where(x => x.Attr is not null)
                .OrderBy(x => x.Attr.SomeIntValue)
                .Select(x => new
                {
                    Type = x.Prop.Type.Name,
                    PropertyName = x.Prop.Name,
                    Label = x.Attr.SomeDataCode,
                })
                .ToList();

            result.Should().HaveCount(2);
            result.Should().Contain(x => x.Label == "Identifier" && x.Type == "String" && x.PropertyName == "Id");
            result.Should().Contain(x => x.Label == "UserName" && x.Type == "String" && x.PropertyName == "Name");
        }
    }
}
