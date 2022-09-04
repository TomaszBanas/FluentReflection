using FluentReflection.Abstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentReflection.Abstraction
{
    public interface IFluentReflection : IFluentElement
    {
        IFluentType Type { get; }
        List<IFluentProperty> Properties { get; }
        List<IFluentMethod> Methods { get; }
    }
}
