using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using math_expressions.ExpressionSolver;
using math_expressions.ExpressionSolver.Factory;

namespace math_expressions.Test
{
    [TestClass]
    public class ExpressionMathSolverTest
    {
        [TestMethod]
        public void TestAddition()
        {
            IMathExpressionSolver solver = ExpressionSolverFactory.GetSolver(Solver.CSharpMathSolver);
            string expression = "2+1";

            double result = solver.Solve(expression);

            Assert.AreEqual(3d, result);
        }

        [TestMethod]
        public void TestSubtraction()
        {
            IMathExpressionSolver solver = ExpressionSolverFactory.GetSolver(Solver.CSharpMathSolver);
            string expression = "10-1";

            double result = solver.Solve(expression);

            Assert.AreEqual(9d, result);
        }

        [TestMethod]
        public void TestMultiplication()
        {
            IMathExpressionSolver solver = ExpressionSolverFactory.GetSolver(Solver.CSharpMathSolver);
            string expression = "20*5";

            double result = solver.Solve(expression);

            Assert.AreEqual(100d, result);
        }

        [TestMethod]
        public void TestDivision()
        {
            IMathExpressionSolver solver = ExpressionSolverFactory.GetSolver(Solver.CSharpMathSolver);
            string expression = "25/2";

            double result = solver.Solve(expression);

            Assert.AreEqual(12.5d, result);
        }

        [TestMethod]
        public void TestComplexExpression()
        {
            IMathExpressionSolver solver = ExpressionSolverFactory.GetSolver(Solver.CSharpMathSolver);
            string expression = "2+1*3/2+12";

            double result = solver.Solve(expression);

            Assert.AreEqual(15.5d, result);
        }


        [TestMethod]
        public void TestException()
        {
            IMathExpressionSolver solver = ExpressionSolverFactory.GetSolver(Solver.CSharpMathSolver);
            string expression = "assadsad";

            Assert.ThrowsException<ArgumentException>(() =>
            {
                double result = solver.Solve(expression);
            });
        }
    }
}
