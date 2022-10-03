using FluentReflection.Abstraction.Interfaces;
using FluentReflection.Core.Models.Base;
using FluentReflection.Core.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FluentReflection.Core.Models.Common
{
    internal class FluentParameter : BaseElement, IFluentParameter
    {
        internal readonly ParameterInfo _parameterInfo;

        public FluentParameter(ParameterInfo parameterInfo, CacheUtility? cacheUtility = null): base(cacheUtility)
        {
            _parameterInfo = parameterInfo;
        }
        public string Name => string.IsNullOrWhiteSpace(_parameterInfo.Name) ? "not_implemented": _parameterInfo.Name;

        public new IFluentType Type => new FluentType(_parameterInfo.ParameterType);
        internal override MemberInfo MemberInfo => _parameterInfo.Member;
    }
}
