using FluentReflection.Abstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluentReflection.Core.Models.Common
{
    internal class FluentType : IFluentType
    {
        internal readonly MemberInfo _memberInfo;

        public FluentType(MemberInfo memberInfo)
        {
            _memberInfo = memberInfo;
        }

        public string Name => _memberInfo.Name;

        public MemberInfo GetMemberInfo() => _memberInfo;
    }
}
