using System;
using math_expressions.ExpressionSolver;
using math_expressions.ExpressionSolver.Factory;

namespace math_expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            UI ui = UI.Instance;

            ui.DisplayLogo(false);
            ui.GreetUser();
            ui.IntroduceEngines();

            ConsoleKeyInfo keyInfo;

            do
            {
                int option = ui.ChooseEngine();
                IMathExpressionSolver solver = GetEngine(option);

                string expression = ui.GetUserMathExpression();

                try
                {
                    double result = solver.Solve(expression);
                    ui.PresentResult(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                ui.EndMessage();
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        private static IMathExpressionSolver GetEngine(int option)
        {
            switch (option)
            {
                case 2:
                    return ExpressionSolverFactory.GetSolver(Solver.CSharpMathSolver);

                default:
                    return ExpressionSolverFactory.GetSolver(Solver.ExpressionMathSolver);
            }
        }
    }
}
