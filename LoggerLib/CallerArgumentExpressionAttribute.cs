// ReSharper disable once CheckNamespace - For compiler tricks
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    internal sealed class CallerArgumentExpressionAttribute : Attribute
    {
        // ReSharper disable once UnusedParameter.Local
        public CallerArgumentExpressionAttribute(string parameterName)
        {
        }
    }
}