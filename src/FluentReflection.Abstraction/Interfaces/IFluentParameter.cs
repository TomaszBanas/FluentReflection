using System;
using System.Collections.Generic;
using System.Text;

namespace FluentReflection.Abstraction.Interfaces
{
    public interface IFluentParameter : IFluentElement
    {
        string Name { get; }
        IFluentType Type { get; }
    }
}
