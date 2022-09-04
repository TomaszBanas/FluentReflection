using FluentReflection.Abstraction.Interfaces;
using FluentReflection.Core.Models.Common;
using FluentReflection.Core.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace FluentReflection.Core.Models.Base
{
    internal abstract class BaseFluentProperty : BaseElement, IFluentProperty
    {
        internal readonly PropertyInfo _propertyInfo;

        internal BaseFluentProperty(PropertyInfo propertyInfo, CacheUtility? cacheUtility = null) : base(cacheUtility)
        {
            _propertyInfo = propertyInfo;
        }
        public string Name => _propertyInfo.Name;
        public IFluentType Type => new FluentType(_propertyInfo.PropertyType);
        internal override MemberInfo MemberInfo => _propertyInfo;
        public abstract object Value { get; set; }
    }
}
