using System;
using math_expressions.ExpressionProvider;
using math_expressions.ExpressionProvider.ValueProvider.Providers;
using math_expressions.ExpressionSolver;
using math_expressions.ExpressionSolver.MathSolvers;

namespace math_expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello User :)");
            Console.WriteLine("Please paste math expresion:");
            string expression = Console.ReadLine();

            IMathExpressionSolver<string, double> solver = new CSharpMathSolver();
            IMathExpressionSolver<string, double> solver2 = new ExpressionMathSolver(new DefaultExpressionListProvider(new DoubleValueProvider()));
            double result = solver.Solve(expression);
            double result2 = solver2.Solve(expression);
            Console.WriteLine(result);
            Console.WriteLine(result2);

        }
    }
}
