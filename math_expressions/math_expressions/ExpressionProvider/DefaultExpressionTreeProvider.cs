using math_expressions.ExpressionProvider.ValueProvider;
using System.Collections.Generic;
using System.Linq;

namespace math_expressions.ExpressionProvider
{
    public class DefaultExpressionTreeProvider : ExpressionTreeProviderBase
    {
        private readonly char[] operators = { '+', '-', '*', '/' };

        public DefaultExpressionTreeProvider(
            IValueProvider<double> valueProvider) : base(valueProvider) { }


        public override MathExpression GetExpressions(string expression)
        {
            char[] lettes = expression.ToCharArray();
            // in math expression there is always n+1 numbers
            // where n is number of operators
            var queue = CreateNumberQueue(expression);

            // Create tree root element
            MathExpression root = new MathExpression
            {
                Operation = Operation.None,
                Value = queue.Dequeue()
            };

            MathExpression currentExpression = root;

            for (int i = 0; i < lettes.Length; i++)
            {
                if (operators.Contains(lettes[i]))
                {
                    // create child expression
                    currentExpression.Next = new MathExpression
                    {
                        Operation = GetOperation(lettes[i]),
                        Value = queue.Dequeue()
                    };

                    // assign child as parrent
                    currentExpression = currentExpression.Next;
                }
            }

            return root;
        }


        private Queue<double> CreateNumberQueue(string expression)
        {
            var numbers = expression
                .Split(operators)
                .Select(x => valueProvider.GetValue(x));

            return new Queue<double>(numbers);
        }


        private Operation GetOperation(char operation)
        {
            switch (operation)
            {
                case '+':
                    return Operation.Addition;

                case '-':
                    return Operation.Subtraction;

                case '*':
                    return Operation.Multiplication;

                case '/':
                    return Operation.Division;

                default:
                    return Operation.None;
            }
        }
    }
}
