using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            double result = solver.Solve(expression);
            Console.WriteLine(result);

        }
    }
}
