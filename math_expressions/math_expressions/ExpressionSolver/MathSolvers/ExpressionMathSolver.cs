using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math_expressions.ExpressionSolver.MathSolvers
{
    enum Operation
    { a, b, c, d }

    class Expression
    {
        public double LeftSideNumber { get; set; }
        public double RightSideNumber { get; set; }
        public Operation Operation { get; set; }
        public int Priority { get; set; }
    }


    public class ExpressionMathSolver : IMathExpressionSolver<string, double>
    {
        private IList<Expression> expressions;

        public double Solve(string expression)
        {
            double result = 0.0;

            foreach (var exp in expressions)
            {
                result += foo(exp);
            }
            throw new NotImplementedException();
        }


        private double foo(Expression expression)
        {
            switch (expression.Operation)
            {
                case Operation.a:
                    return expression.LeftSideNumber + expression.RightSideNumber
                default:
                    break;
            }
        }
    }
}
