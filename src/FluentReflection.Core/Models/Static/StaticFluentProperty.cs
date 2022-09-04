using FluentReflection.Abstraction.Interfaces;
using FluentReflection.Core.Models.Base;
using FluentReflection.Core.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FluentReflection.Core.Models.Static
{
    internal class StaticFluentProperty : BaseFluentProperty
    {
        public StaticFluentProperty(PropertyInfo propertyInfo, CacheUtility? cacheUtility = null) : base(propertyInfo, cacheUtility) { }

        public override object Value
        {
            get => _propertyInfo.GetValue(null);
            set => _propertyInfo.SetValue(null, value);
        }
    }
}
