using math_expressions.ExpressionProvider.ValueProvider;

namespace math_expressions.ExpressionProvider
{
    public interface IExpressionProvider<T> where T : class
    {
        T GetExpressions(string expression);
    }

    public enum Operation
    { None, Addition, Subtraction, Multiplication, Division }

    public class Expression
    {
        public double Value { get; set; }
        public Operation Operation { get; set; }
        public Expression Next { get; set; }
    }

    public abstract class ExpressionTreeProviderBase : IExpressionProvider<Expression>
    {
        protected readonly IValueProvider<double> valueProvider;

        public ExpressionTreeProviderBase(IValueProvider<double> valueProvider)
        {
            this.valueProvider = valueProvider;
        }

        public abstract Expression GetExpressions(string expression);
    }
}
