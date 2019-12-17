using math_expressions.ExpressionProvider.ValueProvider;

namespace math_expressions.ExpressionProvider
{
    public interface IExpressionProvider<T> where T : class
    {
        T GetExpressions(string expression);
    }

    public enum Operation
    {
        None,
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class MathExpression
    {
        public double Value { get; set; }
        public Operation Operation { get; set; }
        public MathExpression Next { get; set; }

        // override equals to make UT green
        public override bool Equals(object obj)
        {
            if (obj is MathExpression)
            {
                var exp = obj as MathExpression;

                if (exp.Next == null && Next != null)
                    return false;

                if (exp.Next != null && Next != null)
                    return exp.Value == Value
                    && exp.Operation == Operation
                    && exp.Next.Equals(Next);

                return exp.Value == Value
                    && exp.Operation == Operation;
            }

            return false;
        }
    }

    public abstract class ExpressionTreeProviderBase : IExpressionProvider<MathExpression>
    {
        protected readonly IValueProvider<double> valueProvider;

        public ExpressionTreeProviderBase(IValueProvider<double> valueProvider)
        {
            this.valueProvider = valueProvider;
        }

        public abstract MathExpression GetExpressions(string expression);
    }
}
