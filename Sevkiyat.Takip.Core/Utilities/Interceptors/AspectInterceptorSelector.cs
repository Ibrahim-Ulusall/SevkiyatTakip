﻿using Castle.DynamicProxy;
using System.Reflection;

namespace Sevkiyat.Takip.Core.Utilities.Interceptors;

public class AspectInterceptorSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {

        var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
        IEnumerable<MethodInterceptionBaseAttribute>? methodAttributes = type.GetMethod(method.Name)?.
            GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
        if (methodAttributes != null)
            classAttributes.AddRange(methodAttributes);

        return classAttributes.OrderBy(x => x.Priority).ToArray();
    }
}
