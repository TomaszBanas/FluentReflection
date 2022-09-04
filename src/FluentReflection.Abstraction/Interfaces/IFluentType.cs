using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FluentReflection.Abstraction.Interfaces
{
    public interface IFluentType
    {
        string Name { get; }
        MemberInfo GetMemberInfo();
    }
}
