using FluentReflection.Abstraction.Interfaces;
using FluentReflection.Core.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FluentReflection.Core.Models
{
    internal class FluentProperty<T> : IFluentProperty where T : class
    {
        private readonly PropertyInfo _propertyInfo;
        private readonly T _instance;
        private readonly CacheUtility _cacheUtility;

        internal FluentProperty(PropertyInfo propertyInfo, T instance, CacheUtility cacheUtility = null)
        {
            _propertyInfo = propertyInfo;
            _instance = instance;
            _cacheUtility = cacheUtility ?? new CacheUtility();
        }

        public Type Type => _propertyInfo.PropertyType;

        public object Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); } // TODO: implement property Value

        public string Name => _propertyInfo.Name;

        public IFluentModifier Modifier => throw new NotImplementedException(); // TODO: implement property Modifier

        public IEnumerable<IFluentAttribute> Attributes => throw new NotImplementedException(); // TODO: implement property Attributes
    }
}
