using math_expressions.ExpressionProvider;
using System;

namespace math_expressions.ExpressionSolver.MathSolvers
{
    public class ExpressionMathSolver : IMathExpressionSolver<string, double>
    {
        private readonly IExpressionProvider<Expression> expressionListProvider;

        public ExpressionMathSolver(ExpressionTreeProviderBase expressionListProvider)
        {
            this.expressionListProvider = expressionListProvider;
        }

        public double Solve(string expression)
        {
            Expression expressionTree = expressionListProvider.GetExpressions(expression);
            

            double result = expressionTree.Value;

            while (expressionTree.Next != null)
            {
                result = MakeOperation(result, expressionTree.Next.Value, expressionTree.Next.Operation);
                expressionTree = expressionTree.Next;
            }


            return result;
        }

        private double MakeOperation(double currentValue, double nextOperationValue, Operation operation)
        {
            switch (operation)
            {
                case Operation.Addition:
                    return currentValue + nextOperationValue;

                case Operation.Subtraction:
                    return currentValue - nextOperationValue;

                case Operation.Multiplication:
                    return currentValue * nextOperationValue;

                case Operation.Division:
                    if (nextOperationValue == 0)
                        throw new InvalidOperationException("Can't divide by 0");

                    return currentValue / nextOperationValue;

                default:
                    throw new InvalidOperationException($"Could not perform {operation}");
            }
        }
    }
}
