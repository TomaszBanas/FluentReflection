using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentReflection.TestData.TestData.Attributes
{
    internal class Test2Attribute : Attribute
    {
        public string? SomeDataCode { get; set; }
        public int SomeIntValue { get; set; }
    }
}
