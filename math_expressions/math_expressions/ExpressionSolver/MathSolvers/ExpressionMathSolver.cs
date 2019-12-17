using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math_expressions.ExpressionSolver.MathSolvers
{
    public class ExpressionMathSolver : IMathExpressionSolver<string, double>
    {
        private readonly IExpressionListProvider<Expression> expressionListProvider;

        public ExpressionMathSolver(ExpressionListProviderBase expressionListProvider)
        {
            this.expressionListProvider = expressionListProvider;
        }

        public double Solve(string expression)
        {
            IEnumerable<Expression> expressions = expressionListProvider.GetExpressions(expression).OrderBy(x => x.Priority);

            double result = 0;

            foreach (var exp in expressions)
            {
                result += MakeArythmeticOperation(exp);
            }

            return result;
        }


        private double MakeArythmeticOperation(Expression expression)
        {
            switch (expression.Operation)
            {
                case Operation.Addition:
                    return expression.LeftSideNumber + expression.RightSideNumber;

                case Operation.Subtraction:
                    return expression.LeftSideNumber - expression.RightSideNumber;

                case Operation.Multiplication:
                    return expression.LeftSideNumber * expression.RightSideNumber;

                case Operation.Division:
                    if (expression.RightSideNumber == 0)
                        throw new InvalidOperationException("Division by 0 is impossible");
                    return expression.LeftSideNumber / expression.RightSideNumber;

                default:
                    throw new InvalidOperationException($"Operation: {expression.Operation} is invalid");
            }
        }
    }
}
