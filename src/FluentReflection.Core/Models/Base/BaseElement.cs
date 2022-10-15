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

        public IFluentType Type => new FluentType(MemberInfo);
        public List<IFluentAttribute> Attributes => _cacheUtility.Value(GetAttributes);
        public IFluentModifier Modifier => _cacheUtility.Value(GetModifiers);
        public bool HasAttribute<T>(Func<T, bool>? filter = null) where T : Attribute => Attributes.Any(x => x.Is<T>(filter));

        internal abstract MemberInfo MemberInfo { get; }
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
    }
}
