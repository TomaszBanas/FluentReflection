using FluentReflection.Abstraction.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentReflection.Abstraction.Interfaces
{
    public interface IFluentElement
    {
        IFluentType Type { get; }
        IFluentModifier Modifier { get; }
        List<IFluentAttribute> Attributes { get; }
        bool HasAttribute<T>(Func<T, bool>? filter = null) where T : Attribute;
    }
}
