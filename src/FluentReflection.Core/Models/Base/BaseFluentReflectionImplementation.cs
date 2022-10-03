using FluentReflection.Abstraction;
using FluentReflection.Abstraction.Enums;
using FluentReflection.Abstraction.Interfaces;
using FluentReflection.Core.Models.Common;
using FluentReflection.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace FluentReflection.Core.Models.Base
{
    internal abstract class BaseFluentReflectionImplementation : BaseElement, IFluentReflection
    {
        internal readonly Type _type;

        internal BaseFluentReflectionImplementation(Type type, CacheUtility? cacheUtility = null) : base(cacheUtility)
        {
            _type = type;
        }

        public new IFluentType Type => new FluentType(MemberInfo);
        internal override MemberInfo MemberInfo => _type;
        public List<IFluentProperty> Properties => _cacheUtility.Value(GetProperties);
        public List<IFluentMethod> Methods => _cacheUtility.Value(GetMethods);
        internal abstract List<IFluentProperty> GetProperties();
        internal abstract List<IFluentMethod> GetMethods();
    }
}
