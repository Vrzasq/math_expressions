using math_expressions.ExpressionSolver.ValueProvider;
using System.Collections.Generic;

namespace math_expressions.ExpressionSolver
{
    public interface IExpressionListProvider<T> where T : class
    {
        IEnumerable<T> GetExpressions(string expression);
    }

    public enum Operation
    { Addition, Subtraction, Multiplication, Division }

    public class Expression
    {
        public double LeftSideNumber { get; set; }
        public double RightSideNumber { get; set; }
        public Operation Operation { get; set; }
        public int Priority { get; set; }
    }

    public abstract class ExpressionListProviderBase : IExpressionListProvider<Expression>
    {
        protected readonly IValueProvider<double> valueProvider;

        public ExpressionListProviderBase(IValueProvider<double> valueProvider)
        {
            this.valueProvider = valueProvider;
        }

        public abstract IEnumerable<Expression> GetExpressions(string expression);
    }
}
