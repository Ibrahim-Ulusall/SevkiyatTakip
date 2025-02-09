using Castle.DynamicProxy;

namespace Sevkiyat.Takip.Core.Utilities.Interceptors;

public abstract class MethodInterception : MethodInterceptionBaseAttribute
{
    protected virtual void OnBefore(IInvocation invocation) { }
    protected virtual void OnAfter(IInvocation invocation) { }
    protected virtual void OnSuccess(IInvocation invocation) { }
    protected virtual void OnException(IInvocation invocation, Exception e) { }

    public override void Intercept(IInvocation invocation)
    {
        bool success = true;

        OnBefore(invocation);
        try
        {
            invocation.Proceed();
        }
        catch (Exception e)
        {
            success = false;
            OnException(invocation, e);
            throw;
        }
        finally
        {
            if (success)
                OnSuccess(invocation);
        }
        OnAfter(invocation);
    }
}
