using math_expressions.ExpressionProvider.ValueProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math_expressions.ExpressionProvider
{
    public class DefaultExpressionTreeProvider : ExpressionTreeProviderBase
    {
        public DefaultExpressionTreeProvider(IValueProvider<double> valueProvider): base(valueProvider) { }

        Expression mockData = new Expression
        {
            Value = 1,
            Operation = Operation.None,
            Next = new Expression
            {
                Value = 53,
                Operation = Operation.Multiplication,
                Next = new Expression
                {
                    Value = 2,
                    Operation = Operation.Division,
                    Next = new Expression
                    {
                        Value = 15,
                        Operation = Operation.Addition,
                        Next = new Expression
                        {
                            Value = 3,
                            Operation = Operation.Subtraction
                        }
                    }
                }

            }
        };

        public override Expression GetExpressions(string expression)
        {
            return mockData;
        }
            
    }
}
