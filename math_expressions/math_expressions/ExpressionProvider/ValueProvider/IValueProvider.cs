namespace math_expressions.ExpressionProvider.ValueProvider
{
    public interface IValueProvider<T>
    {
        T GetValue(string value);
    }
}
