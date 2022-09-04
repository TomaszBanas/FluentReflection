using FluentReflection.Abstraction.Interfaces;
using FluentReflection.Core.Models.Base;
using FluentReflection.Core.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace FluentReflection.Core.Models.Instanced
{
    internal class InstancedFluentProperty<T> : BaseFluentProperty where T : class
    {
        private readonly T? _instance;

        internal InstancedFluentProperty(PropertyInfo propertyInfo, T? instance, CacheUtility? cacheUtility = null) : base(propertyInfo, cacheUtility)
        {
            _instance = instance;
        }

        public override object Value
        {
            get => _propertyInfo.GetValue(_instance);
            set => _propertyInfo.SetValue(_instance, value);
        }
    }
}
