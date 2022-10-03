using FluentAssertions;
using FluentReflection.Core.Extensions;
using FluentReflection.TestData.TestData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FluentReflection.CoreTests.Tests
{
    public class FluentReflectionNameTests
    {
        [Fact()]
        public void NamePropertyIsCorrect()
        {
            var model = new ClassWithAttributes();
            var test = model.AsReflection();
            test.Type.Name.Should().Be("ClassWithAttributes");
        }
    }
}
