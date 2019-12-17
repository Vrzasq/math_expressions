using math_expressions.ExpressionProvider;
using math_expressions.ExpressionProvider.ValueProvider.Providers;
using math_expressions.ExpressionSolver.MathSolvers;

namespace math_expressions.ExpressionSolver.Factory
{
    public enum Solver
    {
        ExpressionMathSolver, CSharpMathSolver
    }

    public static class ExpressionSolverFactory
    {
        public static IMathExpressionSolver GetSolver(Solver solver)
        {
            MathSolverCreator mathSolver = null;

            switch (solver)
            {
                case Solver.ExpressionMathSolver:
                    mathSolver = new ExpressionMathCreator();
                    break;

                case Solver.CSharpMathSolver:
                    mathSolver = new CSharpMathCreator();
                    break;
            }

            return mathSolver.Solver;
        }
    }

    public abstract class MathSolverCreator
    {
        public MathSolverCreator()
        {
            Solver = CreateSolver();
        }

        protected abstract IMathExpressionSolver CreateSolver();

        public IMathExpressionSolver Solver { get; }
    }

    class CSharpMathCreator : MathSolverCreator
    {
        protected override IMathExpressionSolver CreateSolver()
        {
            return new CSharpMathSolver();
        }
    }

    class ExpressionMathCreator : MathSolverCreator
    {
        protected override IMathExpressionSolver CreateSolver()
        {
            var valueProvider = new DoubleValueProvider();
            var expressionProvider = new DefaultExpressionTreeProvider(valueProvider);

            return new ExpressionMathSolver(expressionProvider);
        }
    }
}
