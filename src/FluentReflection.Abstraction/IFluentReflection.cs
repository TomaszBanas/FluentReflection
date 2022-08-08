using FluentReflection.Abstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentReflection.Abstraction
{
    public interface IFluentReflection : IFluentElement
    {
        IEnumerable<IFluentProperty> Properties { get; }
        IEnumerable<IFluentMethod> Methods { get; }
    }
}
