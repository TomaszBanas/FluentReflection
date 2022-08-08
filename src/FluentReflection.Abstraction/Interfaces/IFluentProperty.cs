using System;
using System.Collections.Generic;
using System.Text;

namespace FluentReflection.Abstraction.Interfaces
{
    public interface IFluentProperty : IFluentElement
    {
        Type Type { get; }
        object Value { get; set; }
    }
}
