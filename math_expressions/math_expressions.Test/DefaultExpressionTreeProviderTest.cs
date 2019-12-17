using Microsoft.VisualStudio.TestTools.UnitTesting;
using math_expressions.ExpressionSolver.MathSolvers;
using math_expressions.ExpressionSolver.Factory;
using math_expressions.ExpressionProvider;
using math_expressions.ExpressionProvider.ValueProvider.Providers;

namespace math_expressions.Test
{
    [TestClass]
    public class DefaultExpressionTreeProviderTest
    {
        [TestMethod]
        public void TestCSharpMathSolverCreation()
        {
            IExpressionProvider<MathExpression> provider = new DefaultExpressionTreeProvider(new DoubleValueProvider());
            string expression = "1+2/3+5";
            MathExpression targetExpression = BuildTree();

            MathExpression mathExpression = provider.GetExpressions(expression);

            Assert.AreEqual(targetExpression, mathExpression);
        }

        private MathExpression BuildTree() =>
            new MathExpression
            {
                Value = 1,
                Operation = Operation.None,
                Next = new MathExpression
                {
                    Value = 2,
                    Operation = Operation.Addition,
                    Next = new MathExpression
                    {
                        Value = 3,
                        Operation = Operation.Division,
                        Next = new MathExpression
                        {
                            Value = 5,
                            Operation = Operation.Addition
                        }
                    }
                }
            };
    }
}
