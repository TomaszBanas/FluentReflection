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
    internal abstract class BaseElement : IFluentElement
    {
        internal readonly CacheUtility _cacheUtility;

        protected BaseElement(CacheUtility? cacheUtility = null)
        {
            _cacheUtility = cacheUtility ?? new CacheUtility();
        }

        internal abstract MemberInfo MemberInfo { get; }
        public IFluentType Type => new FluentType(MemberInfo);
        public List<IFluentAttribute> Attributes => _cacheUtility.Value(GetAttributes);
        public IFluentModifier Modifier => _cacheUtility.Value(GetModifiers);

        private IFluentModifier GetModifiers()
        {
            return new FluentModifier
            {
                Modifiers = ModifierUtility.ToModifiers(MemberInfo)
            };
        }

        private List<IFluentAttribute> GetAttributes()
        {
            var attributes = MemberInfo.GetCustomAttributes(true);
            return attributes.Select(x => x as Attribute).Where(x => x != null).Select(x => new FluentAttribute(x)).Cast<IFluentAttribute>().ToList();
        }

        public bool HasAttribute<T>(Func<T, bool>? filter = null) where T : Attribute
        {
            if (filter == null)
                return Attributes.Any(x => x.Name == typeof(T).Name);

            return Attributes.Any(x => x.GetInstance() is T t && filter(t));
        }
    }
}
