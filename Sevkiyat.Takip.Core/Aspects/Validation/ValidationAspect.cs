using Castle.DynamicProxy;
using FluentValidation;
using Sevkiyat.Takip.Core.Utilities.Interceptors;
using Sevkiyat.Takip.Core.Utilities.Validation;

namespace Sevkiyat.Takip.Core.Aspects.Validation;

public class ValidationAspect : MethodInterception
{
    private Type _validationType;

    public ValidationAspect(Type validationType)
    {
        if (!typeof(IValidator).IsAssignableFrom(validationType))
            throw new Exception("this class not validation class");
        _validationType = validationType;
    }

    protected override void OnBefore(IInvocation invocation)
    {
        IValidator validator = (IValidator)Activator.CreateInstance(_validationType)!;
        var entityType = _validationType.BaseType?.GenericTypeArguments[0];
        var entities = invocation.Arguments.Where(i => i.GetType() == entityType).ToList();
        foreach (var entity in entities)
        {
            ValidationTool.Validate(validator, entity);
        }
    }

}
