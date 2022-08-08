using FluentReflection.Abstraction.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentReflection.Abstraction.Interfaces
{
    public interface IFluentElement
    {
        string Name { get; }
        IFluentModifier Modifier { get; }
        IEnumerable<IFluentAttribute> Attributes { get; }
    }
}
