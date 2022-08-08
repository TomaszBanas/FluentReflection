using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentReflection.TestData.TestData.Attributes
{
    internal class TestAttribute : Attribute
    {

        public string? SomeDataCode { get; set; }
        public int SomeIntValue { get; set; }
        //public TestAttribute(string? SomeDataCode = null, int? SomeIntValue = null)
        //{
        //    this.SomeDataCode = SomeDataCode;
        //    this.SomeIntValue = SomeIntValue;
        //}
    }
}
