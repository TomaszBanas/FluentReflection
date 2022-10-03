using FluentReflection.Abstraction.Interfaces;
using FluentReflection.Core.Models.Base;
using FluentReflection.Core.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FluentReflection.Core.Models.Class
{
    internal class ClassFluentProperty : BaseFluentProperty
    {
        public ClassFluentProperty(PropertyInfo propertyInfo, CacheUtility? cacheUtility = null) : base(propertyInfo, cacheUtility) { }

        public override object Value
        {
            get => _propertyInfo.GetValue(null);
            set => _propertyInfo.SetValue(null, value);
        }
    }
}
