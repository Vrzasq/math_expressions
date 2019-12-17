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
            IMathExpressionSolver<string, double> solver2 = new ExpressionMathSolver(new DefaultExpressionTreeProvider(new DoubleValueProvider()));
            double result = solver.Solve("1+1+3*1*4/5/5/3*34/23*324-100");
            double result2 = solver2.Solve("1+1+3*1*4/5/5/3*34/23*324-100");
            Console.WriteLine(result);
            Console.WriteLine(result2);

        }
    }
}
