using System;
using System.Collections.Generic;
using System.Text;

namespace FluentReflection.Abstraction.Interfaces
{
    public interface IFluentProperty : IFluentElement
    {
        string Name { get; }
        object Value { get; set; }
    }
}
