using Microsoft.VisualStudio.TestTools.UnitTesting;
using math_expressions.ExpressionSolver.MathSolvers;
using math_expressions.ExpressionSolver;
using math_expressions.ExpressionSolver.Factory;

namespace math_expressions.Test
{
    [TestClass]
    public class ExpressionFactoryTest
    {
        [TestMethod]
        public void TestCSharpMathSolverCreation()
        {
            IMathExpressionSolver solver = ExpressionSolverFactory.GetSolver(Solver.CSharpMathSolver);

            Assert.IsInstanceOfType(solver, typeof(CSharpMathSolver));
        }

        [TestMethod]
        public void TestExpressionMathSolverCreation()
        {
            IMathExpressionSolver solver = ExpressionSolverFactory.GetSolver(Solver.ExpressionMathSolver);

            Assert.IsInstanceOfType(solver, typeof(ExpressionMathSolver));
        }
    }
}
