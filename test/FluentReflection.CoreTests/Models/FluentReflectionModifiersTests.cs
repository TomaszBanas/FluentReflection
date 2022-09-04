using FluentAssertions;
using FluentReflection.Abstraction.Enums;
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
    public class FluentReflectionModifiersTests
    {
        [Fact()]
        public void InternalClassModifiersIsCorrect()
        {
            var model = new InternalClass();
            var test = model.AsFluentReflection();
            test.Modifier.Modifiers.HasFlag(Modifier.Internal).Should().BeTrue();
            test.Modifier.Modifiers.HasFlag(Modifier.Public).Should().BeFalse();
        }
        
        [Fact()]
        public void InternalStaticClassModifiersIsCorrect()
        {
            var test = ReflectionExtensions.AsFluentReflectionStatic(typeof(InternalStaticClass));
            test.Modifier.Modifiers.HasFlag(Modifier.Internal).Should().BeTrue();
            test.Modifier.Modifiers.HasFlag(Modifier.Static).Should().BeTrue();
            test.Modifier.Modifiers.HasFlag(Modifier.Public).Should().BeFalse();
        }
    }
}
