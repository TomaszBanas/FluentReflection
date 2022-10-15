using FluentReflection.Abstraction.Enums;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluentReflection.Core.Utils
{
    internal static class ModifierUtility
    {
        internal static Modifier ToModifiers(MemberInfo memberInfo) => memberInfo switch
        {
            Type type =>                                                    ToModifiers(type),
            MethodInfo methodInfo =>                                        ToModifiers(methodInfo),
            PropertyInfo propertyInfo =>                                    ToModifiers(propertyInfo),
            _ =>                                                            throw new NotImplementedException()
        };

        private static Modifier ToModifiers(Type type)
        {
            var result = Modifier.None;
            if ( type.IsPublic)                                             result |= Modifier.Public;
            if ( type.IsNotPublic)                                          result |= Modifier.Internal;
            if ( type.IsAbstract && type.IsSealed)                          result |= Modifier.Static;
            if ( !(type.IsAbstract && type.IsSealed) && type.IsSealed)      result |= Modifier.Sealed;
            if ( !(type.IsAbstract && type.IsSealed) && type.IsAbstract)    result |= Modifier.Abstract;
            return result;
        }

        private static Modifier ToModifiers(MethodInfo method)
        {
            var result = Modifier.None;
            if ( method.IsPublic )                                          result |= Modifier.Public;
            if ( method.IsPrivate )                                         result |= Modifier.Private;
            if ( method.IsStatic )                                          result |= Modifier.Static;
            if ( method.ReturnType == typeof(Task) )                        result |= Modifier.Async;
            if ( method.IsVirtual )                                         result |= Modifier.Virtual;
            if ( method.IsAbstract )                                        result |= Modifier.Abstract;
            if ( !method.IsPublic && !method.IsPrivate )                    result |= Modifier.Internal;
            if ( method.IsConstructor )                                     result |= Modifier.Constructor;
            return result;
        }

        private static Modifier ToModifiers(PropertyInfo property)
        {
            var result = Modifier.None;
            return result;
        }
    }
}
