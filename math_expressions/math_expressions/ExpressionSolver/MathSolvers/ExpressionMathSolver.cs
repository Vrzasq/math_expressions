﻿using math_expressions.ExpressionProvider;
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

            //skip root and assign its value to extras
            double result = 0.0;
            result = ResolveTree(result, expressionTree.Next, expressionTree.Value);

            return result;
        }


        // Recursivlly go down the tree
        // IMPORTANT dont forget to return :)
        // otherway Your expression will unfold which will result with unpredicted behaviour
        private double ResolveTree(double result, Expression expressionTree, double extras)
        {
            if (expressionTree == null)
                return result + extras;


            if (HasPriority(expressionTree.Operation))
            {
                extras = MakeOperation(extras, expressionTree.Value, expressionTree.Operation);
                return ResolveTree(result, expressionTree.Next, extras);
            }

            // if next operation has priority over current one
            // assing current value to extras and move to next expression
            if (expressionTree.Next != null
                && HasPriority(expressionTree.Next.Operation))
            {
                extras = expressionTree.Value;
                return ResolveTree(result, expressionTree.Next, extras);
            }

            result = MakeOperation(result, expressionTree.Value, expressionTree.Operation) + extras;
            extras = 0.0;

            return ResolveTree(result, expressionTree.Next, extras);
        }


        private bool HasPriority(Operation operation) =>
            operation == Operation.Multiplication || operation == Operation.Division;


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
