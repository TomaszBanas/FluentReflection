using FluentAssertions;
using FluentReflection.Core.Extensions;
using FluentReflection.TestData.TestData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FluentReflection.CoreTests.Models
{
    public class FluentReflectionNameTests
    {
        [Fact()]
        public void NamePropertyIsCorrect()
        {
            var model = new ClassWithAttributes();
            var test = model.AsFluentReflection();
            test.Name.Should().Be("ClassWithAttributes");
        }
    }
}
