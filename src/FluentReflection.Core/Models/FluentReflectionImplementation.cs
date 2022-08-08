using FluentReflection.Abstraction;
using FluentReflection.Abstraction.Enums;
using FluentReflection.Abstraction.Interfaces;
using FluentReflection.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentReflection.Core.Models
{
    internal class FluentReflectionImplementation<T> : IFluentReflection where T : class
    {
        private readonly T _instance;
        private readonly CacheUtility _cacheUtility;

        internal FluentReflectionImplementation(T instance, CacheUtility cacheUtility = null)
        {
            _instance = instance;
            _cacheUtility = cacheUtility ?? new CacheUtility();
        }

        public IEnumerable<IFluentProperty> Properties => _cacheUtility.Value(GetProperties);
        public IEnumerable<IFluentMethod> Methods => _cacheUtility.Value(GetMethods);
        public string Name => _cacheUtility.Value(GetName);
        public IFluentModifier Modifier => _cacheUtility.Value(GetModifiers);
        public IEnumerable<IFluentAttribute> Attributes => _cacheUtility.Value(GetAttributes);


        private string GetName()
        {
            return _instance.GetType().Name;
        }

        private IFluentModifier GetModifiers()
        {
            throw new NotImplementedException(); // TODO: implement method GetModifiers
        }
        
        private IEnumerable<IFluentAttribute> GetAttributes()
        {
            throw new NotImplementedException(); // TODO: implement method GetAttributes
        }
        
        private IEnumerable<IFluentMethod> GetMethods()
        {
            throw new NotImplementedException(); // TODO: implement method GetMethods
        }

        private IEnumerable<IFluentProperty> GetProperties()
        {
            throw new NotImplementedException(); // TODO: implement method GetProperties
        }
    }
}
