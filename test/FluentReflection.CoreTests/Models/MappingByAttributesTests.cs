using Xunit;
using FluentReflection.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using FluentReflection.TestData.TestData.Models;
using FluentReflection.TestData.TestData.Attributes;
using FluentReflection.Core.Extensions;

namespace FluentReflection.Core.Models.Tests
{
    public class MappingByAttributesTests
    {
        [Fact()]
        public void AddTest()
        {
            var model = new ClassWithAttributes();
            var test = model.AsFluentReflection();
            var name1 = test.Name;
            var name2 = test.Name;
            var name3 = test.Name;
        }
    }
}