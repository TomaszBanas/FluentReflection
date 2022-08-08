using FluentReflection.TestData.TestData.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentReflection.TestData.TestData.Models
{
    internal class ClassWithAttributes
    {
        [Test(SomeDataCode = "test1", SomeIntValue = 1)]
        public string? MyProperty1 { get; set; }
        [Test(SomeDataCode = "test2", SomeIntValue = 2)]
        public string? MyProperty2 { get; set; }
        [Test(SomeDataCode = "test3", SomeIntValue = 3)]
        public string? MyProperty3 { get; set; }
    }
}
